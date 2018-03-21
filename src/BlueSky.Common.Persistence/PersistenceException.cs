namespace BlueSky.Common.Persistence
{
    using BlueSky.Core;
    using System;

    /// <summary>
    /// Serves as the base exception class for BlueSky Persistence library exceptions.
    /// </summary>
    public class PersistenceException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceException"/>
        /// class.
        /// </summary>
        public PersistenceException() :
            base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceException"/>
        /// class.
        /// </summary>
        public PersistenceException(string message) :
            base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceException"/>
        /// class.
        /// </summary>
        public PersistenceException(string message, Exception inner) :
            base(message, inner)
        {
        }
    }
}
