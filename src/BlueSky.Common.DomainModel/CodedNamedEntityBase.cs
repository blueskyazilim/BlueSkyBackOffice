namespace BlueSky.Common.DomainModel
{
    using Core.DesignByContract;
    using System;

    /// <summary>
    /// Serves as the base class for entities with Code, Name and Description
    /// properties.
    /// </summary>
    public abstract class CodedNamedEntityBase :
        VersionedEntityBase<int>,
        ICodedNamedEntity
    {
        protected CodedNamedEntityBase()
        {
        }

        protected CodedNamedEntityBase(
            string code,
            string name,
            string description)
        {
            this.Code = code;
            this.Name = name;
            this.Description = description;
        }

        /// <summary>
        /// Gets or sets the code of this coded-named entity.
        /// </summary>
        public virtual string Code
        {
            get { return this.code; }
            set
            {
                Require.That(value, Is.NotNull);

                this.code = value;
            }
        }

        private string code;

        /// <summary>
        /// Gets or sets the name of this coded-named entity.
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

        /// <summary>
        /// Gets or sets the description of this coded-named entity.
        /// </summary>
        public virtual string Description { get; set; }
    }
}