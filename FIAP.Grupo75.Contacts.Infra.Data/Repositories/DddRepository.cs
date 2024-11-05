using FIAP.Grupo75.Contacts.Domain.Entities;
using FIAP.Grupo75.Contacts.Domain.Interfaces;
using FIAP.Grupo75.Contacts.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FIAP.Grupo75.Contacts.Infra.Data.Repositories
{
    public class DddRepository :IDddRepository
    {
        private ApplicationDbContext _dddContext;

        public DddRepository(ApplicationDbContext context)
        {
            _dddContext = context;
        }

        public async Task<Ddd> CreateAsync(Ddd ddd)
        {
            _dddContext.Add(ddd);
            await _dddContext.SaveChangesAsync();
            return ddd;
        }

        public async Task<Ddd> RemoveAsync(Ddd ddd)
        {
            _dddContext.Remove(ddd);
            await _dddContext.SaveChangesAsync();
            return ddd;
        }

        public async Task<Ddd> UpdateAsync(Ddd ddd)
        {
            _dddContext.Update(ddd);
            await _dddContext.SaveChangesAsync();
            return ddd;
        }

        public async Task<Ddd> GetByIdAsync(int? id)
        {
            return await _dddContext.Ddd.FindAsync(id);
        }

        public async Task<Ddd> GetByDddAsync(string ddd)
        {
            return await _dddContext.Ddd.FirstOrDefaultAsync(d => d.Code.Equals(ddd));
        }

        public async Task<IEnumerable<Ddd>> GetDddAsync()
        {
            return await _dddContext.Ddd
                            .OrderBy(c => c.RegionName)
                            .ToListAsync();
        }

        public async Task<IEnumerable<Ddd>> GetBySearchAsync(string search)
        {
            return await _dddContext.Ddd.Where(
                d => d.RegionName.Contains(search) || d.Code.Contains(search))
                                    .OrderBy(c => c.RegionName)
                                    .ToListAsync();
        }
    }
}
