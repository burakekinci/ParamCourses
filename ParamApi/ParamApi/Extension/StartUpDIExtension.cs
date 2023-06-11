using ParamApi.Data.UnitOfWork.Abstract;
using ParamApi.Data.UnitOfWork.Concrete;

namespace ParamApi.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<ScopeService>();
            //services.AddSingleton<SingletonService>();
            //services.AddTransient<TransientService>();


        }
    }
}
