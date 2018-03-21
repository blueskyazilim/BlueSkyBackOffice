namespace BlueSky.Common.DomainModel
{

    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Base repository interface for a read-only repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Entity type.
    /// </typeparam>
    /// <typeparam name="TId">
    /// Type of the specified entity's id.
    /// </typeparam>
    public interface IReadOnlyRepository<TEntity, TId>
        : IRepository
        where TEntity : IEntity
    {
        /// <summary>
        /// Gets the entity instance with the specified id from the repository.
        /// </summary>
        TEntity GetById(TId id);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filterExpression);
    }
}