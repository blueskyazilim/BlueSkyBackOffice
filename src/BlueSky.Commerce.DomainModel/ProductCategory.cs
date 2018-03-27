namespace BlueSky.Commerce.DomainModel
{
    using Common.DomainModel;
    using Core.DesignByContract;
    using System;

    public interface IProductCategoryRepository :
        ICrudRepository<ProductCategory, int>
    {

    }

    public class ProductCategory : VersionedEntityBase<int>
    {
        protected ProductCategory() { }

        protected internal ProductCategory(
            Product product,
            Category category,
            int displayOrder)
        {
            this.Product = product;
            this.Category = category;
            this.DisplayOrder = displayOrder;
        }

        public virtual Product Product
        {
            get { return this.product; }
            protected set
            {
                Require.That(value, Is.NotNull);

                this.product = value;
            }
        }

        public virtual Category Category
        {
            get { return this.category; }
            protected set
            {
                Require.That(value, Is.NotNull);

                this.category = value;
            }
        }

        public virtual int DisplayOrder { get; set; }

        private Product product;
        private Category category;
    }
}
