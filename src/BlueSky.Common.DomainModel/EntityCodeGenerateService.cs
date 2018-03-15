namespace BlueSky.Common.DomainModel
{
    using System;

    public class EntityCodeGenerateService : IService
    {
        public string GenerateCodeFor<TEntity>()
            where TEntity : ICodedNamedEntity
        {
            return GenerateCodeFor(typeof(TEntity));
        }

        public string GenerateCodeFor(Type entityType)
        {
            if (!typeof(ICodedNamedEntity).IsAssignableFrom(entityType))
            {
                throw new DomainModelException("Specified entity type must be an ICodedNamedEntity");
            }

            return GenerateCodeFor(entityType.FullName);
        }

        public string GenerateCodeFor(string entityTypeFullName)
        {
            EntityCodeTemplate template = this.EntityCodeTemplateRepository
                .SingleOrDefault(x => x.EntityTypeName == entityTypeFullName);

            if (template == null)
            {
                throw new DomainModelException("No template for the specified entity exists.");
            }

            string generatedCode = template.GenerateCode();

            this.EntityCodeTemplateRepository.Update(template);

            return generatedCode;
        }


        public IEntityCodeTemplateRepository EntityCodeTemplateRepository;
    }
}
