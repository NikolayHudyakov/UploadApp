using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using UploadApp.Models;
using UploadApp.Services;
using UploadApp.ViewModels;

namespace UploadApp.IoC
{
    internal static class ServicesRegistrator
    {
        public static void AddServices(this ContainerBuilder builder)
        {
            builder.RegisterType<SettingsStorageService>().As<ISettingsStorageService<SettingsDto>>().SingleInstance();
            builder.RegisterType<TcpClientService>().As<ITcpClientService>();
        }
    }
}
