using AutoMapper;
using FIAP.Grupo75.Contacts.Application.DTOs;
using FIAP.Grupo75.Contacts.Domain.Entities;

namespace FIAP.Grupo75.Contacts.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Contact, ContactDTO>()
                .ReverseMap()
                .ForMember(d => d.Ddd, o => o.Ignore());
            CreateMap<Ddd, DddDTO>().ReverseMap();
        }
    }
}
