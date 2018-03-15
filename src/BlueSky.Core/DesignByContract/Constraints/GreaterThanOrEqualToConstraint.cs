namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given values are
    /// greater than or equal to the specified minimum value.
    /// </summary>
    public class GreaterThanOrEqualToConstraint : IConstraint
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="GreaterThanOrEqualToConstraint" /> class.
        /// </summary>
        public GreaterThanOrEqualToConstraint(object minimumValue)
        {
            this.minimumValue = minimumValue;
        }

        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given value
        /// must be greater than or equal to the minimum value.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            IComparable comparableValue = value as IComparable;

            if (comparableValue == null)
            {
                throw new ArgumentException("'value' must be an IComparable.");
            }

            return comparableValue.CompareTo(minimumValue) >= 0;
        }

        #endregion

        public override string ToString()
        {
            return String.Format("GreaterThanOrEqualToConstraint[{0}]", this.minimumValue);
        }

        private object minimumValue;
    }
}
