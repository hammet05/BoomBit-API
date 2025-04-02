using AutoMapper;
using TestBoomBit.Application.DTO;
using TestBoomBit.Application.Interface.Application;
using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Common;
using TestBoomBit.Domain.Entities;
using TestBoomBit.Infraestructure.Repositories;

namespace TestBoomBit.Application.UseCases.Users
{
    public class UsersApplication : IUserApplication
    {
        private readonly IMapper? _mapper;
        private readonly IUnitOfWork? _unitOfWork;
        private readonly IActivitiesRepository _activityRepository;
       

        public UsersApplication(IMapper? mapper, IUnitOfWork? unitOfWork, IActivitiesRepository activityRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _activityRepository = activityRepository;
        }

        public async Task<Response<User>> Create(UserDto userDto)
        {
            var user = _mapper!.Map<User>(userDto);
            var createdUser= await _unitOfWork!.Users!.Create(user);

            await _activityRepository.LogActivityAsync(new Activity
            {
                ActivityDescription = "Usuario Creado",
                IdUser = user.IdUser,               
            });
            
            return new Response<User> { Data = createdUser, Success = true, Message = "Registro creado satisfactoriamente" };
        }
        
        public async Task<Response<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _unitOfWork!.Users!.GetAll();
            var mappedCountries = _mapper!.Map<IEnumerable<UserDto>>(users);

            return new Response<IEnumerable<UserDto>>
            {
                Data = mappedCountries,
                Success = mappedCountries.Any(),
                Message = "Usuarios encontrados satisfactoriamente"
            };
        }

        public async Task<Response<User>> Update(int id, UserDto userDto)
        {
            var mapUser = _mapper!.Map<User>(userDto);
            var user = await _unitOfWork!.Users.Update(id, mapUser);

            if (user == null)
            {
                return new Response<User>
                {
                    Success = false,
                    Message = "Usuario no encontrado"
                };
            }
            await _activityRepository.LogActivityAsync(new Activity
            {
                ActivityDescription = "User Updated",
                IdUser = user.IdUser,
            });

            return new Response<User>
            {
                Data = user,
                Success = true,
                Message = "Usuario actualizado correctamente"
            };
        }
        public async Task<Response<User>> GetUserById(int id)
        {
            var user = await _unitOfWork!.Users.GetUserById(id);

            if (user == null)
            {
                return new Response<User>
                {
                    Success = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new Response<User>
            {
                Data = user,
                Success = true
            };
        }
        public async Task<Response<bool>>DeleteUserById(int id)
        {
            var deleted = await _unitOfWork!.Users.DeleteUserById(id);

            if (!deleted)
            {
                return new Response<bool>
                {
                    Success = false,
                    Message = "Usuario no encontrado"
                };
            }
                                      
            await _activityRepository.LogActivityAsync(new Activity
            {
                ActivityDescription = "User Deleted",                    
                IdUser = id,
                DateCreated = DateTime.Now  
            });
           

            return new Response<bool>
            {
                Data = deleted,
                Success = deleted,
                Message = deleted ? "Usuario eliminado correctamente" : "Error al eliminar el usuario"
            };
        }
       
    }
}
