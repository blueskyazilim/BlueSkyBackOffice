namespace BlueSky.Common.DomainModel
{
    public interface INavigatableRepository<TEntity, TId>
        where TEntity : IEntity
    {
        TEntity GetNextItem(TId id);

        TEntity GetPreviousItem(TId id);
    }
}