namespace BlueSky.Common.DomainModel
{
    /// <summary>
    /// Base repository interface for a CRU (CRUD minus D) repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Entity type.
    /// </typeparam>
    /// <typeparam name="TId">
    /// Type of the specified entity's id.
    /// </typeparam>
    public interface ICruRepository<TEntity, TId>
        : IUpdatableRepository<TEntity, TId>
        where TEntity : IEntity
    {
        /// <summary>
        /// Adds the specified entity instance to the repository.
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);
    }
}