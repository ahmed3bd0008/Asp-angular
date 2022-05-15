using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
namespace TestApplication.Extension
{
    public static class ConnectedSqlExtension
    {
        public static void ConnectedSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContextTest>(opt=>opt.UseSqlServer(configuration.
                                                                GetConnectionString("apiTestContext"),
                                                                    d=>d.MigrationsAssembly("aspApi")));
        }
    }
}
