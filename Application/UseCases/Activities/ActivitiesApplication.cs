using AutoMapper;
using TestBoomBit.Application.DTO;
using TestBoomBit.Application.Interface.Application;
using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Common;
using TestBoomBit.Domain.Entities;

namespace TestBoomBit.Application.UseCases.Activities
{
    public class ActivitiesApplication : IActivitiesApplication
    {
        private readonly IMapper? _mapper;
        private readonly IUnitOfWork? _unitOfWork;

        public ActivitiesApplication(IMapper? mapper, IUnitOfWork? unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Create(ActivitiesDto activitiesDto)
        {
            var activity = _mapper!.Map<Activity>(activitiesDto);
            var result = await _unitOfWork!.Activities!.Create(activity);

            return new Response<bool> { Data = result, Success = result, Message = "Registro creado satisfactoriamente" };
        }

        public async Task<Response<IEnumerable<ActivitiesDtoGet>>> GetAll()
        {
            var activities = await _unitOfWork!.Activities!.GetAll();
            var activitiesWithUsers = new List<ActivitiesDtoGet>();
            
            foreach (var activity in activities)
            {
                var user = await _unitOfWork.Users.GetUserById(activity.IdUser);

                var activityDto = new ActivitiesDtoGet
                {
                    UserId = user.IdUser,
                    ActivityDate= activity.DateCreated,
                    User = user?.UserName ?? "UnKnown", 
                    ActivityDescription = activity.ActivityDescription
                };

                activitiesWithUsers.Add(activityDto);
            }
            
            return new Response<IEnumerable<ActivitiesDtoGet>>
            {
                Data = activitiesWithUsers,
                Success = activitiesWithUsers.Any(),
                Message = activitiesWithUsers.Any() ? "Actividades encontradas satisfactoriamente" : "No se encontraron actividades"
            };
            
        }
    }
}
