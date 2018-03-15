namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    public class PostConditionException : BlueSkyException
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PostConditionException" /> class.
        /// </summary>
        public PostConditionException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PostConditionException" /> class.
        /// </summary>
        public PostConditionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="PostConditionException" /> class.
        /// </summary>
        public PostConditionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}