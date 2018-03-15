namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given values are
    /// equal to the specified value to compare.
    /// </summary>
    public class EqualToConstraint : IConstraint
    {
        public EqualToConstraint(object valueToCompare)
        {
            this.valueToCompare = valueToCompare;
        }

        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given value
        /// must be equal to the value to compare.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            IComparable comparableValue = value as IComparable;

            if (comparableValue == null)
            {
                throw new ArgumentException("'value' must be an IComparable.");
            }

            return comparableValue.CompareTo(this.valueToCompare) == 0;
        }

        #endregion

        public override string ToString()
        {
            return String.Format("EqualToConstraint[{0}]", this.valueToCompare);
        }

        private object valueToCompare;
    }
}
