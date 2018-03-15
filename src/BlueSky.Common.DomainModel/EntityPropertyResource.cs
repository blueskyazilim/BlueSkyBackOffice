namespace BlueSky.Common.DomainModel
{
    using Core.DesignByContract;
    using System;

    public interface IEntityPropertyResourceRepository :
        ICrudRepository<EntityPropertyResource, int>,
        INavigatableRepository<EntityPropertyResource, int>
    {

    }

    /// <summary>
    /// Represents an entity property resource. These entries are used to
    /// localize the parts of the application, which are directly related to
    /// entities in the system.
    /// </summary>
    public class EntityPropertyResource : ResourceBase
    {
        /// <summary>
        /// Initializes a blank instance of the <see cref="EntityPropertyResource" />
        /// class.
        /// </summary>
        protected EntityPropertyResource() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityPropertyResource" />
        /// class.
        /// </summary>
        public EntityPropertyResource(
            Language language,
            string entityTypeName,
            string name,
            string value,
            string comments)
            : base(language, value, comments)
        {
            this.EntityTypeName = entityTypeName;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the type name of the related entity property.
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

        /// <summary>
        /// Gets or sets the name of the related entity property.
        /// </summary>
        public virtual string Name
        {
            get { return this.name; }
            set
            {
                Require.That(value, Is.NotNull);

                this.name = value;
            }
        }

        private string name;
    }
}
