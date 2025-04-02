using Microsoft.EntityFrameworkCore;
using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Common;
using TestBoomBit.Domain.Entities;
using TestBoomBit.Infraestructure.Context;

namespace TestBoomBit.Infraestructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext? _context;

        public CountryRepository(ApplicationDbContext? context)
        {
            _context = context;
        }

        public async Task<bool> Create(Country country)
        {
            _context!.Add(country);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
           return await _context!.Set<Country>().AsNoTracking().ToListAsync();
        }
    }
}
