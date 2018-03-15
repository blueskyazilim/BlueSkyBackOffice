namespace BlueSky.Common.DomainModel
{

    using Core;
    using System;

    /// <summary>
    /// The exception that is thrown when a Domain Model rule/contract is
    /// violated.
    /// </summary>
    public class DomainModelException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DomainModelException" /> class.
        /// </summary>
        public DomainModelException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DomainModelException" /> class.
        /// </summary>
        public DomainModelException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="DomainModelException" /> class.
        /// </summary>
        public DomainModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}