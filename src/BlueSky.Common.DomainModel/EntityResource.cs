namespace BlueSky.Common.DomainModel
{
    using Core.DesignByContract;
    using System;

    public interface IEntityResourceRepository :
        ICrudRepository<EntityResource, int>,
        INavigatableRepository<EntityResource, int>
    {

    }

    /// <summary>
    /// Represents an entity resource. These entries are used to localize the
    /// parts of the application, which are directly related to entities in the
    /// system.
    /// </summary>
    public class EntityResource : ResourceBase
    {
        /// <summary>
        /// Initializes a blank instance of the <see cref="EntityResource" />
        /// class.
        /// </summary>
        protected EntityResource() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityResource" />
        /// class.
        /// </summary>
        public EntityResource(
            Language language,
            string entityTypeName,
            string value,
            string comments)
            : base(language, value, comments)
        {
            this.EntityTypeName = entityTypeName;
        }

        /// <summary>
        /// Gets or sets the type name of the related entity.
        /// </summary>
        public virtual string EntityTypeName
        {
            get { return this.entityTypeName; }
            set
            {
                Require.That(value, Is.NotNull);

                this.entityTypeName = value;
            }
        }

        private string entityTypeName;
    }
}
