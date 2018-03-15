namespace BlueSky.Common.DomainModel
{
    using Core.DesignByContract;
    using System;

    public interface IEnumResourceRepository :
        ICrudRepository<EnumResource, int>,
        INavigatableRepository<EnumResource, int>
    {

    }

    /// <summary>
    /// Represents an enum resource. These entries are used to localize the
    /// enums in the system.
    /// </summary>
    public class EnumResource : ResourceBase
    {
        /// <summary>
        /// Initializes a blank instance of the <see cref="EnumResource" />
        /// class.
        /// </summary>
        protected EnumResource() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumResource" />
        /// class.
        /// </summary>
        public EnumResource(
            Language language,
            string enumTypeName,
            string name,
            string value,
            string comments)
            : base(language, value, comments)
        {
            this.EnumTypeName = enumTypeName;
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets the type name of the related enum.
        /// </summary>
        public virtual string EnumTypeName
        {
            get { return this.enumTypeName; }
            set
            {
                Require.That(value, Is.NotNull);

                this.enumTypeName = value;
            }
        }

        private string enumTypeName;

        /// <summary>
        /// Gets or sets the name of the related enum.
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
