using AutoMapper;
using FIAP.Grupo75.Contacts.Application.DTOs;
using FIAP.Grupo75.Contacts.Application.Interfaces;
using FIAP.Grupo75.Contacts.Domain.Entities;
using FIAP.Grupo75.Contacts.Domain.Interfaces;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace FIAP.Grupo75.Contacts.Application.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        private IDddRepository _dddRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IDddRepository dddRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _dddRepository = dddRepository;
            _mapper = mapper;
        }

        public async Task<ContactGetDTO> Add(ContactDTO contactDTO)
        {
            var entityDdd = _dddRepository.GetByDddAsync(contactDTO.Ddd).Result;
            if (entityDdd == null) return new ContactGetDTO();
            Contact newContact = new Contact(contactDTO.Name, contactDTO.PhoneNumber, contactDTO.Email, entityDdd.Id);
            await _contactRepository.CreateAsync(newContact);
            return ConvertContactToDTO(newContact);
        }

        public async Task<ContactGetDTO> Update(ContactDTO contactDTO)
        {
            var entityDdd = _dddRepository.GetByDddAsync(contactDTO.Ddd).Result;
            contactDTO.DddId = entityDdd.Id;
            var entity = _mapper.Map<Contact>(contactDTO);
            await _contactRepository.UpdateAsync(entity);
            return ConvertContactToDTO(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = _contactRepository.GetByIdAsync(id).Result;
            await _contactRepository.RemoveAsync(entity);
        }

        public async Task<ContactGetDTO> GetById(int id)
        {
            var entity = await _contactRepository.GetByIdAsync(id);
            return ConvertContactToDTO(entity);
        }

        public async Task<IEnumerable<ContactGetDTO>> GetAllContacts()
        {
            var entity = (await _contactRepository.GetContactsAsync()).ToList();
            return ConvertListContactsToContactGetDTO(entity);
        }

        public async Task<IEnumerable<ContactGetDTO>> GetByDdd(string ddd)
        {
            var entity = (await _contactRepository.GetByDddAsync(ddd)).ToList();
            return ConvertListContactsToContactGetDTO(entity);
        }

        public async Task<IEnumerable<ContactGetDTO>> GetBySearch(string search)
        {
            var entity = (await _contactRepository.GetBySearchAsync(search)).ToList();
            return ConvertListContactsToContactGetDTO(entity);
        }

        private List<ContactGetDTO>? ConvertListContactsToContactGetDTO(List<Contact> contacts)
        {
            if (contacts == null || !contacts.Any()) return null;

            List<ContactGetDTO> contactGetDTOs = new List<ContactGetDTO>();

            foreach (var contact in contacts)
                contactGetDTOs.Add(ConvertContactToDTO(contact));

            return contactGetDTOs;
        }

        private ContactGetDTO? ConvertContactToDTO(Contact contact)
        {
            if (contact == null) return null;

            return new ContactGetDTO()
            {
                Id = contact.Id,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Ddd = contact.Ddd.Code,
                Region = contact.Ddd.RegionName,
                CreatedDate = contact.CreatedDate.ToString("dd/MM/yyyy")
            };
        }
    }
}
