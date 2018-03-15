namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given references are
    /// non-null string references with non-whitespace characters in it.
    /// </summary>
    public class NotNullNorWhitespaceStringContraint : IConstraint
    {
        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given
        /// reference must be a non-null string reference, pointing to a string
        /// which has character(s) other than whitespace.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            return
                value != null
                && value is string
                && !String.IsNullOrWhiteSpace((string)value);
        }

        #endregion

        public override string ToString()
        {
            return "NotNullNorWhitespaceStringContraint";
        }
    }
}
