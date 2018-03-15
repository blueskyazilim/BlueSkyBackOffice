namespace BlueSky.Commerce.DomainModel
{
    using Common.DomainModel;
    using System;

    public interface ICategoryRepository : ICruRepository<Category, int> { }

    public class Category : CodedRevisionTrackableEntityBase
    {
        protected Category() { }

        protected internal Category(
            string code,
            string name,
            string description)
            : base(code, name, description)
        {

        }
    }
}
