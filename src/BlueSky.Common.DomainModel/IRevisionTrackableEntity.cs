namespace BlueSky.Common.DomainModel
{
    using System;

    /// <summary>
    /// This interface is used to mark an entity class as "Revision Trackable"
    /// so that revisions of its instances are tracked.
    /// </summary>
    public interface IRevisionTrackableEntity
    {
        /// <summary>
        /// Gets the username of the user who created this instance.
        /// </summary>
        string CreatedByUsername { get; }

        /// <summary>
        /// Gets the creation time of this instance.
        /// </summary>
        DateTime CreationTimeUtc { get; }

        /// <summary>
        /// Gets the username of the user who performed the latest update to
        /// this instance.
        /// </summary>
        string LastUpdatedByUsername { get; }

        /// <summary>
        /// Gets the last update time of this instance.
        /// </summary>
        DateTime? LastUpdateTimeUtc { get; }

        /// <summary>
        /// Gets or sets the description for the latest revision of this
        /// instance.
        /// </summary>
        string RevisionDescription { get; set; }
    }
}