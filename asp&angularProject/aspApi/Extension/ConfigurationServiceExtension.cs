using Microsoft.Extensions.DependencyInjection;
using Repository.Implementation;
using Repository.Interface;
using Services.Implementation;
using Services.Interface;

namespace TestApplication.Extension
{
    public static class ConfigurationServiceExtension
    {
         public static void configurationRepositoryMethod(this IServiceCollection services)
        {
             services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
             services.AddScoped(typeof(IGenericPagedRepository<>),typeof(GenericPagedRepository<>));
            services.AddScoped(typeof(IUntityOfWork),typeof(UntityOfWork));
            services.AddScoped(typeof(ICityRepository),typeof(CityRepository));
            
        }
        public static void configurationServicesMethod(this IServiceCollection services)
        {
            services.AddScoped(typeof(IWorldService), typeof(WorldService));
        }
    }
}