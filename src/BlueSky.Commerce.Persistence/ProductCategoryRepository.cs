namespace BlueSky.Commerce.Persistence
{
    using Common.Persistence;
    using DomainModel;
    using System;

    public class ProductCategoryRepository :
        RepositoryBase<ProductCategory, int>,
        IProductCategoryRepository
    {
    }
}
