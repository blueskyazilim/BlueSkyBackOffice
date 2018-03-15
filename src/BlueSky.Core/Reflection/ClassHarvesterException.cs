namespace BlueSky.Core.Reflection
{
    using System;

    public class ClassHarvesterException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClassHarvesterException"/> class.
        /// </summary>
        public ClassHarvesterException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassHarvesterException"/> class.
        /// </summary>
        public ClassHarvesterException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassHarvesterException"/> class.
        /// </summary>
        public ClassHarvesterException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}