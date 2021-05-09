using Microsoft.Extensions.DependencyInjection;
using DAL;
using BLL.Interfaces;
using BLL.Services;

namespace BLL
{
    public static class Configuration
    {
        public static void ConfigureBllServices(this IServiceCollection services, string connstring)
        {
            services.ConfigurationDalServices(connstring);
            services.AddTransient<IMedicalBillsService, MedicalBillsService>();
            services.AddTransient<IMedicalBillsTypeService, MedicalBillsTypeService>();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IStoreHouseService, StoreHouseService>();
            services.AddTransient<IWaitableListService, WaitableListService>();
            services.AddTransient<IWriteOfListService, WriteOfListService>();
        }
    }
}
