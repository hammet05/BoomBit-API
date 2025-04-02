using TestBoomBit.Domain.Entities;

namespace TestBoomBit.Application.Interface.Persistence
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<IEnumerable<User>> GetAll();

        Task<User> GetUserById(int id);

        Task<bool> DeleteUserById(int id);

        Task<User> Update(int id, User updatedUser);
    }
}
