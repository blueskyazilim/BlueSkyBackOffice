namespace BlueSky.Common.DomainModel
{
    using Core;
    using System;

    public class EventFactorySingletonException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventFactorySingletonException"/> class.
        /// </summary>
        public EventFactorySingletonException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventFactorySingletonException"/> class.
        /// </summary>
        public EventFactorySingletonException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventFactorySingletonException"/> class.
        /// </summary>
        public EventFactorySingletonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}