using TestBoomBit.Application.DTO;
using TestBoomBit.Common;

namespace TestBoomBit.Application.Interface.Application
{
    public interface IActivitiesApplication
    {
        Task<Response<bool>> Create(ActivitiesDto activitiesDto);
        Task<Response<IEnumerable<ActivitiesDtoGet>>> GetAll();
    }
}
