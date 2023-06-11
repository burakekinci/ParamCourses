using Microsoft.EntityFrameworkCore;
using ParamApi.Data.Context;

namespace ParamApi.Extension
{
    public static class StartupDbContextExtension
    {
        public static void AddDBContextDI(this IServiceCollection services, IConfiguration configuration)
        {
            var dbType = configuration.GetConnectionString("DbType");
            if (dbType == "SQL")
            {
                var dbConfig = configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(dbConfig));
            }
            else if (dbType == "PostgreSQL")
            {
                var dbConfig = configuration.GetConnectionString("PostgreSqlConnection");
                services.AddDbContext<AppDbContext>(options => options.UseNpgsql(dbConfig));
            }
        }
    }
}
