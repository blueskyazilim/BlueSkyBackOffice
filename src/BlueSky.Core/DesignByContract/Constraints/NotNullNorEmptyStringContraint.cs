namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given references are
    /// non-null string references with a length greater than zero.
    /// </summary>
    public class NotNullNorEmptyStringContraint : IConstraint
    {
        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given
        /// reference must be a non-null string reference, pointing to a string
        /// which has one or more characters in it.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            return
                value != null
                && value is string
                && !String.IsNullOrEmpty((string)value);
        }

        #endregion

        public override string ToString()
        {
            return "NotNullNorEmptyStringContraint";
        }
    }
}
