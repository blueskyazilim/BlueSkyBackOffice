namespace BlueSky.Common.DomainModel
{
    using System;

    public interface ILanguageRepository : 
        ICrudRepository<Language,int>,
        INavigatableRepository<Language, int>
    {

    }

    public class Language : CodedRevisionTrackableEntityBase
    {
        protected Language() { }

        public Language(
            string code,
            string name,
            string description)
            : base(code, name, description)
        {

        }
    }
}
