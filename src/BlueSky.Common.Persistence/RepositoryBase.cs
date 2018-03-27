namespace BlueSky.Common.Persistence
{
    using DomainModel;
    using System;
    using System.Linq.Expressions;

    public abstract class RepositoryBase<TEntity, TId>
        where TEntity : IEntity
    {
        public virtual void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(TId id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filterExpression)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetNextItem(TId id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetPreviousItem(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
