namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given values are
    /// between the specified start and end values.
    /// </summary>
    public class BetweenConstraint : IConstraint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BetweenConstraint" />
        /// class.
        /// </summary>
        public BetweenConstraint(IComparable startValue, IComparable endValue)
        {
            if (startValue.CompareTo(endValue) > 0)
            {
                throw new ArgumentException("Invalid 'startValue', 'endValue' pair. 'startValue' must be less than or equal to 'endValue'.");
            }

            this.startValue = startValue;
            this.endValue = endValue;
        }

        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given value
        /// must be between the specified start and end values.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            IComparable comparableValue = value as IComparable;

            if (comparableValue == null)
            {
                throw new ArgumentException("'value' must be a non-null IComparable.");
            }

            return ((comparableValue.CompareTo(startValue) >= 0)
                && (comparableValue.CompareTo(endValue) <= 0));
        }

        #endregion

        public override string ToString()
        {
            return String.Format("BetweenConstraint[{0}..{1}]", this.startValue, this.endValue);
        }

        private IComparable startValue;
        private IComparable endValue;
    }
}
