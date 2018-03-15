namespace BlueSky.Core.Helpers
{
    using System;

    public class HelperFactorySingletonException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelperFactorySingletonException"/> class.
        /// </summary>
        public HelperFactorySingletonException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelperFactorySingletonException"/> class.
        /// </summary>
        public HelperFactorySingletonException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelperFactorySingletonException"/> class.
        /// </summary>
        public HelperFactorySingletonException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}