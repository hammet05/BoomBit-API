using TestBoomBit.Application.DTO;
using TestBoomBit.Common;
using TestBoomBit.Domain.Entities;

namespace TestBoomBit.Application.Interface.Application
{
    public interface IUserApplication
    {
        Task<Response<User>> Create(UserDto userDto);
        Task<Response<IEnumerable<UserDto>>> GetAll();        
        Task<Response<User>> Update(int id, UserDto userDto);
        Task<Response<bool>> DeleteUserById(int id);

        Task<Response<User>> GetUserById(int id);

    }
}
