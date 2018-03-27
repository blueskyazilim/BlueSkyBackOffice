namespace BlueSky.Common.WebFramework
{
    using Core;
    using System;

    /// <summary>
    /// The exception that is thrown when a Web Framework rule/contract is
    /// violated.
    /// </summary>
    public class BlueSkyWebFrameworkException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BlueSkyWebFrameworkException" /> class.
        /// </summary>
        public BlueSkyWebFrameworkException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BlueSkyWebFrameworkException" /> class.
        /// </summary>
        public BlueSkyWebFrameworkException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="BlueSkyWebFrameworkException" /> class.
        /// </summary>
        public BlueSkyWebFrameworkException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
