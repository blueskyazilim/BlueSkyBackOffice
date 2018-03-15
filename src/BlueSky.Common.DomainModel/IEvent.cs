namespace BlueSky.Common.DomainModel
{
    public interface IEvent
    {
        int Order { get; }

        void Handle(object arg);
    }
}
