using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Domain.Entities;
using TestBoomBit.Infraestructure.Context;

namespace TestBoomBit.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext? _applicationDbContext;
        public IUserRepository? Users { get; }

        public IActivitiesRepository? Activities { get; }

        public ICountryRepository? Countries { get; }

        public UnitOfWork(ApplicationDbContext applicationDbContext, IUserRepository userRepository, IActivitiesRepository activitiesRepository, ICountryRepository countryRepository)
        {
            _applicationDbContext = applicationDbContext;

            Users = userRepository;
            Activities = activitiesRepository;
            Countries = countryRepository;
            
        }

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
