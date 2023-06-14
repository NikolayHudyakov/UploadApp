using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using UploadApp.Models;
using UploadApp.Services;
using UploadApp.ViewModels;

namespace UploadApp.IoC
{
    internal class CrossplatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.AddViewModels();
            builder.AddServices();
        }
    }
}
