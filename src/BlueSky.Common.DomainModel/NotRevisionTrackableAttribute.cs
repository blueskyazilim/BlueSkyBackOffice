namespace BlueSky.Common.DomainModel
{
    using System;

    /// <summary>
    /// Used to mark a property of an entity as "not revision-trackable",
    /// meaning revisions of the associated property will not be tracked and
    /// will not appear in the entity revision log.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class NotRevisionTrackableAttribute : Attribute
    {
    }
}
