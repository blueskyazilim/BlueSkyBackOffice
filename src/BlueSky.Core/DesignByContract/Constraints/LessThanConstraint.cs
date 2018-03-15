namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given values are less
    /// than the specified maximum value.
    /// </summary>
    public class LessThanConstraint : IConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LessThanConstraint" />
        /// class.
        /// </summary>
        public LessThanConstraint(object maximumValue)
        {
            this.maximumValue = maximumValue;
        }

        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given value
        /// must be less than the maximum value.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            IComparable comparableValue = value as IComparable;

            if (comparableValue == null)
            {
                throw new ArgumentException("'value' must be an IComparable.");
            }

            return comparableValue.CompareTo(maximumValue) < 0;
        }

        #endregion

        public override string ToString()
        {
            return String.Format("LessThanConstraint[{0}]", this.maximumValue);
        }

        private object maximumValue;
    }
}
