using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace FIAP.Grupo75.Contacts.Application.DTOs
{
    public class ContactGetDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Ddd { get; set; }

        public string Region { get; set; }

        public string CreatedDate { get; set; }
    }
}
