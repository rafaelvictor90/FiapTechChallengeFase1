using FIAP.Grupo75.Contacts.Domain.Entities;

namespace FIAP.Grupo75.Contacts.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContactsAsync();
        Task<IEnumerable<Contact>> GetByDddAsync(string ddd);
        Task<IEnumerable<Contact>> GetBySearchAsync(string search);
        Task<Contact> GetByIdAsync(int? id);

        Task<Contact> CreateAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Task<Contact> RemoveAsync(Contact contact);
    }
}