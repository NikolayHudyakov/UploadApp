using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UploadApp.CustomViews;
using UploadApp.Droid.Services.Camera;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CameraPreview = UploadApp.CustomViews.CameraPreview;

[assembly: ExportRenderer(typeof(CameraPreview), typeof(CameraViewServiceRenderer))]
namespace UploadApp.Droid.Services.Camera
{
    internal class CameraViewServiceRenderer : ViewRenderer<CameraPreview, CameraDroid>
    {
        public static CameraDroid Camera;
        private CameraPreview _currentElement;

        public CameraViewServiceRenderer(Context context) : base(context) 
        { 
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CameraPreview> e)
        {
            base.OnElementChanged(e);

            Camera = new CameraDroid(Context);

            SetNativeControl(Camera);

            if (e.NewElement != null && Camera != null)
            {
                _currentElement = e.NewElement;
                Camera.SetCameraOption(_currentElement.Camera);
            }
        }
    }
}