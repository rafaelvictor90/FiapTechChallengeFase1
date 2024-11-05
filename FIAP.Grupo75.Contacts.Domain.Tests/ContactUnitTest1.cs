using FIAP.Grupo75.Contacts.Domain.Entities;
using FluentAssertions;
using System.Numerics;

namespace FIAP.Grupo75.Contacts.Domain.Tests
{
    public class ContactUnitTest1
    {

        [Fact(DisplayName = "Create Contact With Valid State")]
        public void CreateContact_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Contact(1, "João", "95784-6871", "joao@hotmail.com", 1);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Contact With Negative Id Value")]
        public void CreateContact_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Contact(-1, "João", "95784-6871", "joao@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        // -- Name

        [Fact(DisplayName = "Create Contact With Short Value Name")]
        public void CreateContact_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Contact(1, "Jo", "95784-6871", "joao@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Contact With Null Value Name")]
        public void CreateContact_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Contact(1, null, "95784-6871", "joao@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Contact With Empty Value Name")]
        public void CreateContact_WithEmptyNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Contact(1, "", "95784-6871", "joao@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid name. Name is required");
        }

        // -- E-mail

        [Fact(DisplayName = "Create Contact With Null Value E-mail")]
        public void CreateContact_WithNullEmailValue_DomainExceptionInvalidEmail()
        {
            Action action = () => new Contact(1, "Thais", "95475-9876", null, 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid e-mail. E-mail is required");
        }

        [Fact(DisplayName = "Create Contact With Empty Value E-mail")]
        public void CreateContact_WithEmptyEmailValue_DomainExceptionInvalidEmail()
        {
            Action action = () => new Contact(1, "Thais", "95784-6871", "", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid e-mail. E-mail is required");
        }

        [Fact(DisplayName = "Create Contact With Short Value E-mail")]
        public void CreateContact_ShortEmailValue_DomainExceptionShortEmail()
        {
            Action action = () => new Contact(1, "Thais", "95784-6871", "th", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid e-mail, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Contact With Invalid Value E-mail")]
        public void CreateContact_WithIncorrectFormatEmailValue_DomainExceptionIncorrectFormat()
        {
            Action action = () => new Contact(1, "Thais", "95784-6871", "thaisthais", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Incorrect format. E-mail is required");
        }

        // -- Phone Number

        [Fact(DisplayName = "Create Contact With Null Value Phone Number")]
        public void CreateContact_WithNullPhoneNumberValue_DomainExceptionInvalidNumber()
        {
            Action action = () => new Contact(1, "Aluno", null, "aluno@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid phone number. Phone number is required");
        }

        [Fact(DisplayName = "Create Contact With Short Value Phone Number")]
        public void CreateContact_WithShortPhoneNumberValue_DomainExceptionInvalidNumber()
        {
            Action action = () => new Contact(1, "Aluno", "2125-15", "aluno@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid phone number, too short, minimum 8 characters");
        }

        [Fact(DisplayName = "Create Contact With Empty Value Phone Number")]
        public void CreateContact_WithLongPhoneNumberValue_DomainExceptionInvalidNumber()
        {
            Action action = () => new Contact(1, "Aluno", "11 121251-515421", "aluno@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid phone number, too long, maximum 15 characters");
        }

        [Fact(DisplayName = "Create Contact With Incorrect Format Value Phone Number")]
        public void CreateContact_WithIncorrectFormatPhoneNumberValue_DomainExceptionIncorrectFormatNumber()
        {
            Action action = () => new Contact(1, "Aluno", "121515421", "aluno@hotmail.com", 1);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Incorrect format. Phone number is required");
        }

        // -- DDD

        [Fact(DisplayName = "Create Contact With Short Value DDD")]
        public void CreateContact_WithoutDDDValue_DomainExceptionInvalidDDD()
        {
            Action action = () => new Contact(1, "Aluno", "2125-15", "aluno@hotmail.com", 0);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid DDD. DDD is required");
        }
    }
}
