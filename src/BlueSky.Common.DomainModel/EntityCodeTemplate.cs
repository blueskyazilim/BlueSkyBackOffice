namespace BlueSky.Common.DomainModel
{
    using Core.DesignByContract;
    using System;

    public interface IEntityCodeTemplateRepository :
       ICruRepository<EntityCodeTemplate, int>,
       INavigatableRepository<EntityCodeTemplate, int>
    {
    }

    public class EntityCodeTemplate : VersionedEntityBase<int>
    {
        protected EntityCodeTemplate() { }

        public EntityCodeTemplate(
            string entityTypeName,
            string prefixString,
            byte digitCount,
            long lastNumber)
        {
            this.EntityTypeName = entityTypeName;
            this.PrefixString = prefixString;
            this.DigitCount = digitCount;
            this.LastNumber = lastNumber;
        }

        /// <summary>
        /// Generates a new code based on the values of this template. Throws if
        /// this template is out of codes.
        /// </summary>
        protected internal virtual string GenerateCode()
        {
            if (this.LastNumber >= Math.Pow(10, this.DigitCount) - 1)
            {
                throw new DomainModelException("This template is out of codes.");
            }

            this.LastNumber++;

            return $"{this.PrefixString}{this.LastNumber.ToString().PadLeft(this.DigitCount, '0')}";
        }
        public virtual string EntityTypeName
        {
            get { return this.entityTypeName; }
            protected set
            {
                Require.That(value, Is.NotNull);

                this.entityTypeName = value;
            }
        }

        private string entityTypeName;

        public virtual string PrefixString
        {
            get { return this.prefixString; }
            set
            {
                Require.That(value, Is.NotNull);

                this.prefixString = value;
            }
        }

        private string prefixString;

        public virtual byte DigitCount
        {
            get { return this.digitCount; }
            set
            {
                Require.That(value, Is.Between((byte)1, (byte)16));

                this.digitCount = value;
            }
        }

        private byte digitCount;

        public virtual long LastNumber
        {
            get { return this.lastNumber; }
            set
            {
                Require.That(value, Is.GreaterThanOrEqualTo(0L));

                this.lastNumber = value;
            }
        }

        private long lastNumber;
    }
}
