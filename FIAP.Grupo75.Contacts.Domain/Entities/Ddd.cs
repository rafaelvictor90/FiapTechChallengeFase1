using FIAP.Grupo75.Contacts.Domain.Validation;

namespace FIAP.Grupo75.Contacts.Domain.Entities
{
    public sealed class Ddd : Entity
    {
        public string Code { get; private set; }
        public string RegionName { get; private set; }

        public ICollection<Contact> Contacts { get; set; }

        public Ddd(string code, string regionName)
        {
            ValidateDomain(code, regionName);
        }

        public Ddd(int id, string code, string regionName)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(code, regionName);
        }

        private void ValidateDomain(string code, string regionName)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(code),
                "Invalid code. Code is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(regionName),
                "Invalid region name. Region name is required");

            DomainExceptionValidation.When(code.Length != 2,
                "Invalid code, only 2 characters allowed");

            DomainExceptionValidation.When(regionName.Length < 3,
                "Invalid region name, too short, minimum 3 characters");

            DomainExceptionValidation.When(regionName.Length > 100,
                "Invalid region name, too long, maximum 100 characters");

            Code = code;
            RegionName = regionName;
        }
    }
}