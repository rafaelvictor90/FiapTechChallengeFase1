using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;
using FIAP.Grupo75.Contacts.Domain.Entities;

namespace FIAP.Grupo75.Contacts.Application.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Invalid name, too short, minimum 3 characters")]
        [MaxLength(250, ErrorMessage = "Invalid name, too long, maximum 250 characters")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MinLength(8, ErrorMessage = "Invalid phone number, too short, minimum 8 characters")]
        [MaxLength(15, ErrorMessage = "Invalid phone number, too long, maximum 15 characters")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-mail is required")]
        [MinLength(3, ErrorMessage = "Invalid phone number, too short, minimum 3 characters")]
        [MaxLength(100, ErrorMessage = "Invalid phone number, too long, maximum 100 characters")]
        [DisplayName("Phone Number")]
        public string Email { get; set; }

        [JsonIgnore]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; private set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Invalid code, only 2 characters allowed")]
        [DisplayName("Code DDD")]
        public string Ddd { get; set; }

        [JsonIgnore]
        public int DddId { get;  set; }
    }
}
