using BLL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BLL.Interfaces;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
        }

        private void ConfigureServices(ServiceCollection serviceDescriptors)
        {
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StoreHouse;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            serviceDescriptors.ConfigureBllServices(connString);
            serviceProvider = serviceDescriptors.BuildServiceProvider();

          
            MainWindow = new MainWindow(serviceProvider);
            MainWindow.Show();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ServiceCollection serviceDescriptors = new ServiceCollection();
            ConfigureServices(serviceDescriptors);
        }
    }
}
