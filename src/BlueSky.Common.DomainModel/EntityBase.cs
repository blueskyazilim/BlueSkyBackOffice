namespace BlueSky.Common.DomainModel
{
    /// <summary>
    /// Serves as the base class for entities which are not using any optimistic
    /// locking properties.
    /// </summary>
    /// <typeparam name="TId">
    /// Type of the entity's id. Allowed: System.Int32, System.Decimal,
    /// System.Guid.
    /// </typeparam>
    public abstract class EntityBase<TId> : IEntity
    {
        /// <summary>
        /// Gets the "Id" of this entity.
        /// </summary>
        public virtual TId Id { get; protected internal set; }
    }
}