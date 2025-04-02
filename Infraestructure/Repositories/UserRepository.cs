using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Domain.Entities;
using TestBoomBit.Infraestructure.Context;

namespace TestBoomBit.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext? _context;

        public UserRepository(ApplicationDbContext? context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            _context!.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context!.Set<User>().AsNoTracking().ToListAsync();
        }      
       
        public async Task<User> GetUserById(int id)
        {
            return await _context!.Users!.FindAsync(id);
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var user = await _context!.Users.FindAsync(id);

            if (user == null)
                return false; 
            
            user.Status=false;
            await _context.SaveChangesAsync();

            return true; 
        }

        public async Task<User?> Update(int id, User updatedUser)
        {
            var existingUser = await _context!.Users.FindAsync(id);

            if (existingUser == null)
                return null; 
            
            existingUser.UserName = updatedUser.UserName;
            existingUser.LastName = updatedUser.LastName;
            existingUser.Email = updatedUser.Email;
            existingUser.BirthDate = updatedUser.BirthDate;
            existingUser.Phone = updatedUser.Phone;
            existingUser.IsContacted = updatedUser.IsContacted;
            existingUser.Status = updatedUser.Status;
            existingUser.IdCountry = updatedUser.IdCountry;


            await _context.SaveChangesAsync(); 

            return existingUser; 
        }
    }
}
