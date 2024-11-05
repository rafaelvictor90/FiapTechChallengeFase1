using FIAP.Grupo75.Contacts.Domain.Validation;

namespace FIAP.Grupo75.Contacts.Domain.Entities
{
    public sealed class Contact : Entity
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public int DddId { get; set; }
        public Ddd Ddd { get; set; }

        public Contact(string name, string phoneNumber, string email, int dddId)
        {
            ValidateDomain(name, phoneNumber, email, dddId);
            CreatedDate = DateTime.Now;
        }

        public Contact(int id, string name, string phoneNumber, string email, int dddId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, phoneNumber, email, dddId);
        }

        public void Update(string name, string phoneNumber, string email, int dddId)
        {
            ValidateDomain(name, phoneNumber, email, dddId);
        }

        private void ValidateDomain(string name, string phoneNumber, string email, int dddId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(phoneNumber),
                "Invalid phone number. Phone number is required");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email),
                "Invalid e-mail. E-mail is required");

            DomainExceptionValidation.When(dddId <= 0,
                "Invalid DDD. DDD is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(name.Length > 250,
                "Invalid name, too long, maximum 250 characters");

            DomainExceptionValidation.When(phoneNumber.Length > 15,
                "Invalid phone number, too long, maximum 15 characters");

            DomainExceptionValidation.When(phoneNumber.Length < 8,
                "Invalid phone number, too short, minimum 8 characters");

            DomainExceptionValidation.When(email.Length < 3,
                "Invalid e-mail, too short, minimum 3 characters");

            DomainExceptionValidation.When(email.Length > 100,
                "Invalid e-mail, too long, maximum 100 characters");

            DomainExceptionValidation.When(!FieldValidation.ValidatePhone(phoneNumber),
                "Incorrect format. Phone number is required");

            DomainExceptionValidation.When(!FieldValidation.ValidateEmail(email),
                "Incorrect format. E-mail is required");

            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            DddId = dddId;
        }
    }
}
