using Microsoft.EntityFrameworkCore;
using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Domain.Entities;
using TestBoomBit.Infraestructure.Context;

namespace TestBoomBit.Infraestructure.Repositories
{
    public class ActivityRepository : IActivitiesRepository
    {
        private readonly ApplicationDbContext? _context;

        public ActivityRepository(ApplicationDbContext? context)
        {
            _context = context;
        }

        public async Task<bool> Create(Activity activity)
        {
            _context!.Add(activity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Activity>> GetAll()
        {
            return await _context!.Set<Activity>().AsNoTracking().OrderByDescending(act => act.DateCreated).ToListAsync();
        }

        public async Task<bool> LogActivityAsync(Activity activity)
        {
             _context!.Activities.Add(activity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
