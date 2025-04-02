using TestBoomBit.Domain.Entities;

namespace TestBoomBit.Application.Interface.Persistence
{
    public interface IActivitiesRepository
    {
        Task<bool> Create(Activity activity);
        Task<IEnumerable<Activity>> GetAll();

        Task<bool> LogActivityAsync(Activity activity);


    }
}
