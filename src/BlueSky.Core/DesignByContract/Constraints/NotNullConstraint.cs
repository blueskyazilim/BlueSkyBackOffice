namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given references are not null.
    /// </summary>
    public class NotNullConstraint : IConstraint
    {
        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given
        /// reference must be not-null.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            return value != null;
        }

        #endregion

        public override string ToString()
        {
            return "NotNullConstraint";
        }
    }
}
