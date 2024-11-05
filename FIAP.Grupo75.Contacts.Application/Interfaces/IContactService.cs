using FIAP.Grupo75.Contacts.Application.DTOs;

namespace FIAP.Grupo75.Contacts.Application.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ContactGetDTO>> GetAllContacts();
        Task<ContactGetDTO> GetById(int id);
        Task<IEnumerable<ContactGetDTO>> GetByDdd(string ddd);
        Task<IEnumerable<ContactGetDTO>> GetBySearch(string search);

        Task<ContactGetDTO> Add(ContactDTO contactDTO);
        Task<ContactGetDTO> Update(ContactDTO contactDTO);
        Task Remove(int? id);
    }
}
