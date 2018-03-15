namespace BlueSky.Core.DesignByContract
{
    using Constraints;
    using Helpers;
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Holds the pre-condition check routines.
    /// </summary>
    public class Require
    {
        /// <summary>
        /// Checks whether the given value satisfies the specified constraint;
        /// if not, throws <see cref="PreConditionException" /> with the
        /// specified <paramref name="exceptionMessage" /> (if any) and a
        /// BlueSky-only mini-stack trace.
        /// </summary>
        public static void That(object value, IConstraint constraint, string exceptionMessage = null)
        {
            Hel.per<ConstraintCheckHelper>().AssertConstraintIsSatisfied(value, constraint, exceptionMessage, true);
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
