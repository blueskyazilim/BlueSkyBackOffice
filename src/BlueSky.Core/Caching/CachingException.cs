namespace BlueSky.Core.Caching
{
    using System;

    public class CachingException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CachingException"/>
        /// class.
        /// </summary>
        public CachingException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingException"/>
        /// class.
        /// </summary>
        public CachingException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingException"/>
        /// class.
        /// </summary>
        public CachingException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
