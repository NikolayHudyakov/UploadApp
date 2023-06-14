using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using UploadApp.ViewModels;

namespace UploadApp.IoC
{
    internal static class ViewModelsRegistrator
    {
        public static void AddViewModels(this ContainerBuilder builder)
        {
            builder.RegisterType<MainPageViewModel>();
            builder.RegisterType<SettingsPageViewModel>();
        } 
    }
}
