namespace BlueSky.Common.DomainModel
{
    /// <summary>
    /// Serves as the base interface for entities with Code, Name and
    /// Description properties.
    /// </summary>
    public interface ICodedNamedEntity
    {
        string Code { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}