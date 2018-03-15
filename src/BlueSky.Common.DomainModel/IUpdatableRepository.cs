namespace BlueSky.Common.DomainModel
{
    /// <summary>
    /// Base repository interface for an updatable repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Entity type.
    /// </typeparam>
    /// <typeparam name="TId">
    /// Type of the specified entity's id.
    /// </typeparam>
    public interface IUpdatableRepository<TEntity, TId>
        : IReadOnlyRepository<TEntity, TId>
        where TEntity : IEntity
    {
        /// <summary>
        /// Updates the specified entity instance on the repository.
        /// </summary>
        void Update(TEntity entity);
    }
}