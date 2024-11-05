using FIAP.Grupo75.Contacts.Domain.Entities;

namespace FIAP.Grupo75.Contacts.Domain.Interfaces
{
    public interface IDddRepository
    {
        Task<IEnumerable<Ddd>> GetDddAsync();
        Task<IEnumerable<Ddd>> GetBySearchAsync(string search);
        Task<Ddd> GetByDddAsync(string ddd);
        Task<Ddd> GetByIdAsync(int? id);

        Task<Ddd> CreateAsync(Ddd ddd);
        Task<Ddd> UpdateAsync(Ddd ddd);
        Task<Ddd> RemoveAsync(Ddd ddd);
    }
}