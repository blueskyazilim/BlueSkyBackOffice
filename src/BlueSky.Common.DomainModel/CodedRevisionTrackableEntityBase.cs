namespace BlueSky.Common.DomainModel
{
    using System;

    /// <summary>
    /// Serves as the base class for revision trackable entities with Code,
    /// Name, Description properties.
    /// </summary>
    public abstract class CodedRevisionTrackableEntityBase :
        CodedNamedEntityBase,
        IRevisionTrackableEntity
    {
        /// <summary>
        /// Initializes a blank instance of the <see cref="CodedRevisionTrackableEntityBase"/> class.
        /// </summary>
        protected CodedRevisionTrackableEntityBase() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodedRevisionTrackableEntityBase"/> class.
        /// </summary>
        public CodedRevisionTrackableEntityBase(
            string code,
            string name,
            string description)
            : base(code, name, description)
        {
            this.CreationTimeUtc = DateTime.UtcNow;
        }

        #region IRevisionTrackableEntity Members

        [NotRevisionTrackable]
        public virtual string CreatedByUsername { get; protected set; }

        [NotRevisionTrackable]
        public virtual DateTime CreationTimeUtc { get; protected set; }

        [NotRevisionTrackable]
        public virtual string LastUpdatedByUsername { get; protected set; }

        [NotRevisionTrackable]
        public virtual DateTime? LastUpdateTimeUtc { get; protected set; }

        [NotRevisionTrackable]
        public virtual string RevisionDescription { get; set; }

        #endregion
    }
}
