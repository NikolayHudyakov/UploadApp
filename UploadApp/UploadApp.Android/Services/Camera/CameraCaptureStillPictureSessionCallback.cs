using Android.App;
using Android.Content;
using Android.Hardware.Camera2;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UploadApp.Droid.Services.Camera
{
    internal class CameraCaptureStillPictureSessionCallback : CameraCaptureSession.CaptureCallback
    {
        public Action<CameraCaptureSession> OnCaptureCompletedAction;

        public override void OnCaptureCompleted(CameraCaptureSession session, CaptureRequest request, TotalCaptureResult result)
        {
            OnCaptureCompletedAction?.Invoke(session);
        }
    }
}