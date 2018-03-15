namespace BlueSky.Common.DomainModel
{
    using System;

    /// <summary>
    /// Base repository interface for a CRUD repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Entity type.
    /// </typeparam>
    /// <typeparam name="TId">
    /// Type of the specified entity's id.
    /// </typeparam>
    public interface ICrudRepository<TEntity,TId>
        : ICruRepository<TEntity,TId>
        where TEntity : IEntity
    {
        /// <summary>
        /// Removes the specified entity instance from the repository.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}
