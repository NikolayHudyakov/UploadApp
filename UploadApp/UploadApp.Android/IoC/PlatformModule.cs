using Android.App;
using Android.Content;
using Android.Hardware.Camera2;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UploadApp.Droid.Services.Camera;
using UploadApp.Models;
using UploadApp.Services;

namespace UploadApp.Droid.IoC
{
    internal class PlatformModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<CameraService>().As<ICameraService>();
        }
    }
}