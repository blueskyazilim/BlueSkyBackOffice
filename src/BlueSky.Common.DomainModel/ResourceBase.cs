namespace BlueSky.Common.DomainModel
{
    using Core.DesignByContract;
    using System;

    /// <summary>
    /// Defines the contract and serves as the base class for resource entry
    /// items. These items are used to localize the applications.
    /// </summary>
    public abstract class ResourceBase :
        VersionedEntityBase<int>
    {
        /// <summary>
        /// Initializes a blank instance of the <see cref="RawResourceBase" />
        /// class.
        /// </summary>
        protected ResourceBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RawResourceBase" />
        /// class.
        /// </summary>
        protected ResourceBase(
            Language language,
            string value,
            string comments)
        {
            this.Language = language;
            this.Value = value;
            this.Comments = comments;
        }

        /// <summary>
        /// Gets or sets the language of this resource entry.
        /// </summary>
        public virtual Language Language
        {
            get { return this.language; }
            set
            {
                Require.That(value, Is.NotNull);

                this.language = value;
            }
        }

        private Language language;

        /// <summary>
        /// Gets or sets the localized text for this resource entry.
        /// </summary>
        public virtual string Value { get; set; }

        /// <summary>
        /// Gets or sets the additional information associated with this
        /// resource entry.
        /// </summary>
        public virtual string Comments { get; set; }
    }
}