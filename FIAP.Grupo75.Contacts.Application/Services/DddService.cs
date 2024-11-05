using AutoMapper;
using FIAP.Grupo75.Contacts.Application.DTOs;
using FIAP.Grupo75.Contacts.Application.Interfaces;
using FIAP.Grupo75.Contacts.Domain.Entities;
using FIAP.Grupo75.Contacts.Domain.Interfaces;

namespace FIAP.Grupo75.Contacts.Application.Services
{
    public class DddService : IDddService
    {
        private IDddRepository _dddRepository;
        private readonly IMapper _mapper;

        public DddService(IDddRepository dddRepository, IMapper mapper)
        {
            _dddRepository = dddRepository;
            _mapper = mapper;
        }

        public async Task Add(DddDTO dddDTO)
        {
            var entity = _mapper.Map<Ddd>(dddDTO);
            await _dddRepository.CreateAsync(entity);
            dddDTO.Id = entity.Id;
        }

        public async Task Update(DddDTO dddDTO)
        {
            var entity = _mapper.Map<Ddd>(dddDTO);
            await _dddRepository.UpdateAsync(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = _dddRepository.GetByIdAsync(id).Result;
            await _dddRepository.RemoveAsync(entity);
        }

        public async Task<IEnumerable<DddDTO>> GetAllDdd()
        {
            var entity = (await _dddRepository.GetDddAsync()).ToList();
            return ConvertListDddToDTO(entity);
        }

        public async Task<DddDTO> GetById(int id)
        {
            var entity = await _dddRepository.GetByIdAsync(id);
            return ConvertDddToDTO(entity);
        }

        public async Task<DddDTO> GetByDdd(string ddd)
        {
            var entity = await _dddRepository.GetByDddAsync(ddd);
            return ConvertDddToDTO(entity);
        }

        public async Task<IEnumerable<DddDTO>> GetBySearch(string search)
        {
            var entity = (await _dddRepository.GetBySearchAsync(search)).ToList();
            return ConvertListDddToDTO(entity);
        }

        private List<DddDTO>? ConvertListDddToDTO(List<Ddd> ddd)
        {
            if (ddd == null || !ddd.Any()) return null;

            List<DddDTO> dddDTOs = new List<DddDTO>();

            foreach (var item in ddd)
                dddDTOs.Add(ConvertDddToDTO(item));

            return dddDTOs;
        }

        private DddDTO? ConvertDddToDTO(Ddd ddd)
        {
            if (ddd == null) return null;

            return new DddDTO()
            {
                Id = ddd.Id,
                Code = ddd.Code,
                RegionName = ddd.RegionName
            };
        }
    }
}
