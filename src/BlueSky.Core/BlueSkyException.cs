namespace BlueSky.Core
{
    using System;

    /// <summary>
    /// Serves as the base exception class for BlueSky library exceptions.
    /// </summary>
    public class BlueSkyException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlueSkyException"/>
        /// class.
        /// </summary>
        public BlueSkyException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueSkyException"/>
        /// class.
        /// </summary>
        public BlueSkyException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueSkyException"/>
        /// class.
        /// </summary>
        public BlueSkyException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
