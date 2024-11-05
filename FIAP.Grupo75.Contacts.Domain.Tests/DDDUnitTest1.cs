using FIAP.Grupo75.Contacts.Domain.Entities;
using FluentAssertions;
using System.Numerics;

namespace FIAP.Grupo75.Contacts.Domain.Tests
{
    public class DDDUnitTest1
    {

        [Fact(DisplayName = "Create DDD With Valid State")]
        public void CreateDDD_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Ddd(1, "11", "São Paulo");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create DDD With Negative Id Value")]
        public void CreateContact_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Ddd(-1, "11", "São Paulo");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        // -- Code

        [Fact(DisplayName = "Create DDD With Null Value Code")]
        public void CreateContact_WithNullCodeValue_DomainExceptionInvalidCode()
        {
            Action action = () => new Ddd(1, null, "São Paulo");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid code. Code is required");
        }

        [Fact(DisplayName = "Create DDD With Empty Value Code")]
        public void CreateContact_WithEmptyCodeValue_DomainExceptionInvalidCode()
        {
            Action action = () => new Ddd(1, "", "São Paulo");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid code. Code is required");
        }

        [Fact(DisplayName = "Create DDD with short code value")]
        public void CreateContact_ShortCodeValue_DomainExceptionInvalidCode()
        {
            Action action = () => new Ddd(1, "2", "São Paulo");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid code, only 2 characters allowed");
        }

        [Fact(DisplayName = "Create DDD with long code value")]
        public void CreateContact_LongCodeValue_DomainExceptionInvalidCode()
        {
            Action action = () => new Ddd(1, "123", "São Paulo");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid code, only 2 characters allowed");
        }

        // -- Region Name

        [Fact(DisplayName = "Create DDD With Null Region Name Value")]
        public void CreateContact_WithNullRegionNameValue_DomainExceptionInvalidRegion()
        {
            Action action = () => new Ddd(1, "12", null);
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid region name. Region name is required");
        }

        [Fact(DisplayName = "Create DDD With Empty Region Name Value")]
        public void CreateContact_WithEmptyRegionNameValue_DomainExceptionInvalidRegion()
        {
            Action action = () => new Ddd(1, "12", "");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid region name. Region name is required");
        }

        [Fact(DisplayName = "Create DDD With Short Region Name Value")]
        public void CreateContact_ShortShortValue_DomainExceptionInvalidRegion()
        {
            Action action = () => new Ddd(1, "12", "Ri");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid region name, too short, minimum 3 characters");
        }
    }
}
