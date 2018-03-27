namespace BlueSky.Commerce.DomainModel
{
    using Common.DomainModel;
    using Core.DesignByContract;
    using System;
    using System.Collections.Generic;

    public interface IProductRepository : 
        ICruRepository<Product,int>, 
        INavigatableRepository<Product, int>
    {

    }

    public class Product : CodedRevisionTrackableEntityBase
    {
        protected Product() { }

        protected internal Product(
            string code,
            string name,
            string description) :
            base(code, name, description)
        {
            this.productCategories = new List<ProductCategory>();
        }
        
        public virtual IEnumerable<ProductCategory> ProductCategories
        {
            get { return this.productCategories; }
        }

        protected internal ProductCategory AddCategory(Category category, int displayOrder)
        {
            var productCategory = new ProductCategory(this, category, displayOrder);

            this.productCategories.Add(productCategory);

            return productCategory;
        }

        protected internal void RemoveCategory(ProductCategory productCategory)
        {
            Require.That(productCategory, Is.NotNull);
            Require.That(productCategory.Product, Is.NotNull);
            Require.That(productCategory.Category, Is.NotNull);

            if (this.Id != productCategory.Product.Id)
            {
                throw new Exception();
            }

            this.productCategories.Remove(productCategory);
        }

        private IList<ProductCategory> productCategories;
    }
}
