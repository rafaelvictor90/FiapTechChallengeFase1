using FIAP.Grupo75.Contacts.Application.DTOs;

namespace FIAP.Grupo75.Contacts.Application.Interfaces
{
    public interface IDddService
    {
        Task<IEnumerable<DddDTO>> GetAllDdd();
        Task<DddDTO> GetById(int id);
        Task<IEnumerable<DddDTO>> GetBySearch(string search);
        Task<DddDTO> GetByDdd(string ddd);

        Task Add(DddDTO dddDTO);
        Task Update(DddDTO dddDTO);
        Task Remove(int? id);
    }
}
