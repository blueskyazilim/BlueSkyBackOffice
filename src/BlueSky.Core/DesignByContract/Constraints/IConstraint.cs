namespace BlueSky.Core.DesignByContract.Constraints
{
    /// <summary>
    /// Defines the contract for the constraints.
    /// </summary>
    public interface IConstraint
    {
        /// <summary>
        /// Returns a flag indicating whether the given value satisfies this
        /// constraint.
        /// </summary>
        bool IsSatisfiedBy(object value);
    }
}
