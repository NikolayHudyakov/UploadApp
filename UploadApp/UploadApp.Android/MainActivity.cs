using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using UploadApp.Droid.IoC;
using Android.Content;
using Android.Hardware.Camera2;
using static Android.Hardware.Camera2.CameraDevice;
using Android.Hardware.Camera2.Params;
using Java.Util;
using System.Collections.Generic;
using Android.Util;
using Android.Graphics;
using Java.Util.Jar;
using AndroidX.Core.Content;
using UploadApp.Droid.Models;

namespace UploadApp.Droid
{
    [Activity(Label = "UploadApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (CheckSelfPermission(Android.Manifest.Permission.Camera) != Permission.Granted ||
                ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.WriteExternalStorage) != Permission.Granted)
            {
                RequestPermissions(new string[] { Android.Manifest.Permission.Camera, Android.Manifest.Permission.WriteExternalStorage }, 1);
            }

            LoadApplication(new App(new PlatformModule()));

            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 15, 62, 56));
            
            //var cameraManager = GetSystemService(Context.CameraService) as CameraManager;
            //var list = new List<Size>();
            //foreach (string cameraID in  cameraManager.GetCameraIdList())
            //{
            //    CameraCharacteristics cc = cameraManager.GetCameraCharacteristics(cameraID);
            //    StreamConfigurationMap configurationMap = cc.Get(CameraCharacteristics.ScalerStreamConfigurationMap) as StreamConfigurationMap;
            //    Size[] sizesJpeg = configurationMap.GetOutputSizes((int)ImageFormatType.Jpeg);
            //    list.Add(sizesJpeg[0]);
            //}


            //var cs = new CameraService(cameraManager, "0");
            //cs.OpenCamera();
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}