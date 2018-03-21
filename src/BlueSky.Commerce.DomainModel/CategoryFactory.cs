namespace BlueSky.Commerce.DomainModel
{
    using Common.DomainModel;
    using System;
    using System.Transactions;

    public class CategoryFactory : IFactory
    {
        public Category CreateCategory(
            string code,
            string name,
            string description)
        {

            if (string.IsNullOrEmpty(code))
            {
                code = new EntityCodeGenerateService().GenerateCodeFor<Category>();
            }

            var category = new Category(code, name, description);

            using (var ts = new TransactionScope())
            {
                this.CategoryRepository.Add(category);

                ts.Complete();
            }

            return category;
        }

        public ICategoryRepository CategoryRepository;
    }
}
