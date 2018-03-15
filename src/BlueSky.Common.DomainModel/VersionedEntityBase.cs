namespace BlueSky.Common.DomainModel
{
    /// <summary>
    /// Serves as the base class for entities using version (Int32) properties
    /// for optimistic locking.
    /// </summary>
    /// <typeparam name="TId">
    /// Type of the entity's id. Allowed: System.Int32, System.Decimal,
    /// System.Guid.
    /// </typeparam>
    public abstract class VersionedEntityBase<TId> : EntityBase<TId>
    {
        /// <summary>
        /// Gets the "Version" of this entity. This property is used for
        /// optimistic locking.
        /// </summary>
        public virtual int Version { get; protected internal set; }
    }
}