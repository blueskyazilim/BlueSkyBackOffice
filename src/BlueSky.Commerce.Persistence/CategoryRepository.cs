namespace BlueSky.Commerce.Persistence
{
    using Common.Persistence;
    using DomainModel;
    using System;
    using System.Linq.Expressions;

    public class CategoryRepository :
        RepositoryBase<Category, int>,
        ICategoryRepository
    {

    }
}
