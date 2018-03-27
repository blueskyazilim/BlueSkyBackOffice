namespace BlueSky.Commerce.Persistence
{
    using Common.Persistence;
    using DomainModel;
    using System;

    public class ProductRepository : 
        RepositoryBase<Product,int>,
        IProductRepository
    {
    }
}
