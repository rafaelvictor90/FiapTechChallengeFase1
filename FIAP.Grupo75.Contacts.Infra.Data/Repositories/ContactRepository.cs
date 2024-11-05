using FIAP.Grupo75.Contacts.Domain.Entities;
using FIAP.Grupo75.Contacts.Domain.Interfaces;
using FIAP.Grupo75.Contacts.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Grupo75.Contacts.Infra.Data.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private ApplicationDbContext _contactContext;

        public ContactRepository(ApplicationDbContext context)
        {
            _contactContext = context;
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            _contactContext.Add(contact);
            await _contactContext.SaveChangesAsync();
            return contact;
        }

        public async Task<IEnumerable<Contact>> GetByDddAsync(string ddd)
        {
            return await _contactContext.Contacts
                                    .Include(c => c.Ddd)
                                    .Where(c => c.Ddd.Code.Equals(ddd))
                                    .OrderByDescending(c => c.CreatedDate)
                                    .ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int? id)
        {
            return await _contactContext.Contacts.Include(o => o.Ddd).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Contact>> GetBySearchAsync(string search)
        {
            return await _contactContext.Contacts
                                    .Include(o => o.Ddd)
                                    .Where(c => c.Email.Contains(search)
                                             || c.Name.Contains(search)
                                             || c.PhoneNumber.Contains(search)
                                             || c.Ddd.RegionName.Contains(search))
                                    .OrderByDescending(c => c.CreatedDate)
                                    .ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetContactsAsync()
        {
            return await _contactContext.Contacts
                                    .Include(o => o.Ddd)
                                    .OrderByDescending(c => c.CreatedDate)
                                    .ToListAsync();
        }

        public async Task<Contact> RemoveAsync(Contact contact)
        {
            _contactContext.Remove(contact);
            await _contactContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            _contactContext.Update(contact);
            _contactContext.Entry(contact).Property(c => c.CreatedDate).IsModified = false;
            await _contactContext.SaveChangesAsync();
            return contact;
        }
    }
}
