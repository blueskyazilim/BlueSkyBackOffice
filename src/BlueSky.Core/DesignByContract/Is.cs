namespace BlueSky.Core.DesignByContract
{
    using Constraints;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Provides helper methods and properties which return constraint
    /// instances to be used with Require.That().
    /// </summary>
    public class Is
    {
        /// <summary>
        /// Returns a NotNull constraint.
        /// </summary>
        public static NotNullConstraint NotNull
        {
            get{ return new NotNullConstraint(); }
        }

        /// <summary>
        /// Returns a ValidEnumValue constraint for the specified enum type.
        /// </summary>
        public static ValidEnumValueConstraint AValidValueForEnumType<T>()
        {
            return new ValidEnumValueConstraint(typeof(T));
        }

        /// <summary>
        /// Returns a Between constraint for the specified start and end
        /// values.
        /// </summary>
        public static BetweenConstraint Between(IComparable startValue, IComparable endValue)
        {
            return new BetweenConstraint(startValue, endValue);
        }

        /// <summary>
        /// Returns a GreaterThan constraint for the specified minimum value.
        /// </summary>
        public static GreaterThanConstraint GreaterThan(object minimumValue)
        {
            return new GreaterThanConstraint(minimumValue);
        }

        /// <summary>
        /// Returns a GreaterThanOrEqualTo constraint for the specified minimum
        /// value.
        /// </summary>
        public static GreaterThanOrEqualToConstraint GreaterThanOrEqualTo(object minimumValue)
        {
            return new GreaterThanOrEqualToConstraint(minimumValue);
        }

        /// <summary>
        /// Returns a LessThan constraint for the specified maximum value.
        /// </summary>
        public static LessThanConstraint LessThan(object maximumValue)
        {
            return new LessThanConstraint(maximumValue);
        }

        /// <summary>
        /// Returns a LessThanOrEqualTo constraint for the specified maximum
        /// value.
        /// </summary>
        public static LessThanOrEqualToConstraint LessThanOrEqualTo(object maximumValue)
        {
            return new LessThanOrEqualToConstraint(maximumValue);
        }

        /// <summary>
        /// Returns an EqualTo constraint for the specified value to compare.
        /// </summary>
        public static EqualToConstraint EqualTo(object valueToCompare)
        {
            return new EqualToConstraint(valueToCompare);
        }

        /// <summary>
        /// Returns a NotNullNorEmptyString constraint.
        /// </summary>
        public static NotNullNorEmptyStringContraint NotNullNorEmptyString
        {
            get { return new NotNullNorEmptyStringContraint(); }
        }

        /// <summary>
        /// Returns a NotNullNorWhitespaceString constraint.
        /// </summary>
        public static NotNullNorWhitespaceStringContraint NotNullNorWhitespaceString
        {
            get { return new NotNullNorWhitespaceStringContraint(); }
        }

        #region Object.* intellisense hiding items

        /// <summary>
        /// Hides Object.Equals() in the intellisense for our fluent API.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static bool Equals(object objA, object objB)
        {
            return Object.Equals(objA, objB);
        }

        /// <summary>
        /// Hides Object.ReferenceEquals() in the intellisense for our fluent
        /// API.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new static bool ReferenceEquals(object objA, object objB)
        {
            return Object.ReferenceEquals(objA, objB);
        }

        #endregion
    }
}
