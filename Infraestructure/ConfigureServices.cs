using Microsoft.EntityFrameworkCore;
using TestBoomBit.Application.Interface.Persistence;
using TestBoomBit.Infraestructure.Context;
using TestBoomBit.Infraestructure.Repositories;

namespace TestBoomBit.Infraestructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("connection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivitiesRepository, ActivityRepository>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
