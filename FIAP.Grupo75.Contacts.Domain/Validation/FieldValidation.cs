using System.Text.RegularExpressions;

namespace FIAP.Grupo75.Contacts.Domain.Validation
{
    public static class FieldValidation
    {
        public static bool ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) return false;

            var emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailRegex);
        }

        public static bool ValidatePhone(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return false;

            var phoneNumberRegex = @"^\d{4,5}-\d{4}$";
            return Regex.IsMatch(phoneNumber, phoneNumberRegex);
        }
    }
}
