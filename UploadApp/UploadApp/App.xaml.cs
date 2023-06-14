using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UploadApp.Views;
using Autofac;
using UploadApp.IoC;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;

namespace UploadApp
{
    public partial class App : Application
    {
        public App(Module platformModule)
        {
            InitializeDependecies(platformModule);
            InitializeComponent();
            

            MainPage = new AppShell();
        }

        private void InitializeDependecies(Module platformModule)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new CrossplatformModule());
            builder.RegisterModule(platformModule);
            
            var locator = new AutofacServiceLocator(builder.Build());
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
