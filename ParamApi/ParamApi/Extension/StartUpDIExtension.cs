using ParamApi.Data.UnitOfWork.Abstract;
using ParamApi.Data.UnitOfWork.Concrete;

namespace ParamApi.Extension
{
    public static class StartUpDIExtension
    {
        public static void AddServiceDI(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //services.AddScoped<ScopeService>();           //Request süresince bir kere oluşturulur, request bitince dispose olur
            //services.AddSingleton<SingletonService>();    //API yeniden başlayana kadar servis class'ından yalnızca bir tane bulunur
            //services.AddTransient<TransientService>();    //Requestin her actionında Instance yeniden oluşturulur


        }
    }
}
