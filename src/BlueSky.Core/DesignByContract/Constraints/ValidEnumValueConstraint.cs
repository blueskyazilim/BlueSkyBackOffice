namespace BlueSky.Core.DesignByContract.Constraints
{
    using System;

    /// <summary>
    /// Represents the constraint that checks whether the given values are
    /// valid for the specified enum type.
    /// </summary>
    public class ValidEnumValueConstraint : IConstraint
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ValidEnumValueConstraint" /> class.
        /// </summary>
        public ValidEnumValueConstraint(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType");
            }

            this.enumType = enumType;
        }

        #region IConstraint Members

        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint. In order to satisfy this constraint, the given value
        /// must be a defined value for the specified enum type.
        /// </summary>
        public bool IsSatisfiedBy(object value)
        {
            return Enum.IsDefined(enumType, value);
        }

        #endregion

        public override string ToString()
        {
            return String.Format("ValidEnumValueConstraint[{0}]", this.enumType.Name);
        }

        private Type enumType;
    }
}
