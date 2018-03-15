namespace BlueSky.Common.DomainModel
{
    using Core.Reflection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Event
    {
        public static void Handle<TEvent>(object obj)
            where TEvent : IEvent
        {
            EventFactorySingleton.Instance.InvokeFor<TEvent>(obj);
        }
    }

    public sealed class EventFactorySingleton
    {
        static EventFactorySingleton() { }

        private EventFactorySingleton()
        {
            this.eventHandlers = new Dictionary<string, IList<IEvent>>();

            var eventTypes = ClassHarvester.GetConcreteSubclassesOf<IEvent>();

            foreach (Type eventType in eventTypes)
            {
                var eventInterfaceTypes = eventType.GetInterfaces()
                    .Where(x => typeof(IEvent).IsAssignableFrom(x) && x != typeof(IEvent));

                if (eventInterfaceTypes.Count()==0)
                {
                    throw new EventFactorySingletonException("Cannot retrieve event interface types of the event handler type.");
                }

                var instance = (IEvent)Activator.CreateInstance(eventType);

                foreach (var eventInterfaceType in eventInterfaceTypes)
                {
                    if (!this.eventHandlers.ContainsKey(eventInterfaceType.FullName))
                    {
                        this.eventHandlers[eventInterfaceType.FullName] = new List<IEvent>();
                    }

                    this.eventHandlers[eventInterfaceType.FullName].Add(instance);
                }
            }
        }

        public void InvokeFor<TEvent>(object obj)
            where TEvent : IEvent
        {
            InvokeFor(typeof(TEvent), obj);
        }

        public void InvokeFor(Type eventType,object obj)
        {
            if (!typeof(IEvent).IsAssignableFrom(eventType))
            {
                throw new EventFactorySingletonException("Specified helper type must be an IEvent");
            }
            
            InvokeFor(eventType.FullName, obj);
        }

        public void InvokeFor(string eventTypeFullName, object obj)
        {
            IList<IEvent> list;

            if (!this.eventHandlers.TryGetValue(eventTypeFullName, out list))
            {
                throw new EventFactorySingletonException("Specified helper type must be an IEvent");
            }

            foreach (IEvent @event in list.OrderBy(x=>x.Order))
            {
                @event.Handle(obj);
            }
        }

        private Dictionary<string, IList<IEvent>> eventHandlers;

        internal static readonly EventFactorySingleton Instance = new EventFactorySingleton();
    }
}
