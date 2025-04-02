using System.Reflection;
using TestBoomBit.Application.Interface.Application;
using TestBoomBit.Application.UseCases.Activities;
using TestBoomBit.Application.UseCases.Countries;
using TestBoomBit.Application.UseCases.Users;

namespace TestBoomBit.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICountryApplication, CountriesApplication>();
            services.AddScoped<IUserApplication, UsersApplication>();
            services.AddScoped<IActivitiesApplication, ActivitiesApplication>();
            

            return services;
        }
    }
}
