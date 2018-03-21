namespace BlueSky.Core
{
    using System;

    /// <summary>
    /// Serves as the base exception class for BlueSky bug exceptions.
    /// </summary>
    public class BlueSkyBugException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlueSkyBugException"/>
        /// class.
        /// </summary>
        public BlueSkyBugException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueSkyBugException"/>
        /// class.
        /// </summary>
        public BlueSkyBugException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueSkyBugException"/>
        /// class.
        /// </summary>
        public BlueSkyBugException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
