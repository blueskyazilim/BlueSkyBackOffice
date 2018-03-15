namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// The exception that is thrown when a Pre-Condition is violated.
    /// </summary>
    public class PreConditionException : ArgumentException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PreConditionException" /> class.
        /// </summary>
        public PreConditionException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PreConditionException" /> class.
        /// </summary>
        public PreConditionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PreConditionException" /> class.
        /// </summary>
        public PreConditionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}