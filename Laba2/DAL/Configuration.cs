using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DAL.Contexts;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public static class Configuration
    {
        public static void ConfigurationDalServices(this IServiceCollection services, string connstring)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connstring));
            services.AddTransient<IMedicalBills, MedicalBillsRepository>();
            services.AddTransient<IMedicalBillsType, MedicalBillsTypeRepository>();
            services.AddTransient<IForm, FormRepository>();
            services.AddTransient<IStoreHouse, StoreHouseRepository>();
            services.AddTransient<IWaitableList, WaitableListRepository>();
            services.AddTransient<IWriteOfList, WriteOfListRepository>();
        }
    }
}
