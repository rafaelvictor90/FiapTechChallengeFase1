using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FIAP.Grupo75.Contacts.Application.DTOs
{
    public class DddDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Invalid code, only 2 characters allowed")]
        [DisplayName("Code DDD")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [MinLength(3, ErrorMessage = "Invalid region name, too short, minimum 3 characters")]
        [MaxLength(100, ErrorMessage = "Invalid region name, too long, maximum 100 characters")]
        [DisplayName("Region of the name")]
        public string RegionName { get; set; }

        [JsonIgnore]
        public ICollection<ContactDTO> ContactsDTOs { get; set; }
    }
}
