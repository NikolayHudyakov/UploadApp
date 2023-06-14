using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Hardware.Camera2;
using Android.Hardware.Camera2.Params;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.IO;
using Java.Lang;
using Java.Nio;
using Java.Security;
using Java.Util;
using Java.Util.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UploadApp.Droid.Models
{
    internal class CameraService : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private string _cameraID;
        private CameraDevice _cameraDevice = null;
        private CameraCaptureSession mCaptureSession;
        private CameraManager _cameraManager;
        CameraDevice.StateCallback _stateCallback;

        public CameraService(CameraManager cameraManager, string cameraID)
        {
            _stateCallback = new StateCBack(this);
            _cameraManager = cameraManager;
            _cameraID = cameraID;
        }

        public bool IsOpen()
        {

            if (_cameraDevice == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void OpenCamera()
        {
            try
            {
                //if (CheckSelfPermission(Android.Manifest.Permission.Camera) == Permission.Granted)
                //{

                    _cameraManager.OpenCamera(_cameraID, _stateCallback, null);
                //}
            }
            catch (CameraAccessException e)
            {
                Log.Info("logtag", e.Message);
            }
        }
        public class StateCBack : CameraDevice.StateCallback
        {
            public StateCBack(CameraService cameraService)
            {

            }
            public override void OnDisconnected(CameraDevice camera)
            {
                
            }

            public override void OnError(CameraDevice camera, [GeneratedEnum] CameraError error)
            {
                
            }

            public override void OnOpened(CameraDevice camera)
            {
                ImageReader imageReader = ImageReader.NewInstance(1920, 1080, ImageFormatType.Jpeg, 1);
                //HandlerThread handlerThread = new HandlerThread("camera");
                //handlerThread.Start();
                //Handler handler = new Handler(handlerThread.Looper);
                imageReader.SetOnImageAvailableListener(new ImageAvailableListener(), null);
                
                camera.CreateCaptureSession(new List<Surface>() { imageReader.Surface }, new StateCBackS(camera, imageReader.Surface), null);

             

            }
        }
        public class StateCBackS : CameraCaptureSession.StateCallback
        {
            private CameraDevice _cameraDevice;
            private Surface _surface;
            public StateCBackS(CameraDevice cameraDevice, Surface surface)
            {
                _cameraDevice = cameraDevice;
                _surface = surface;
            }
            
            public override void OnConfigured(CameraCaptureSession session)
            {
                CaptureRequest.Builder builder = _cameraDevice.CreateCaptureRequest(CameraTemplate.StillCapture);
                builder.AddTarget(_surface);
                session.Capture(builder.Build(), new CapCB(), null);
            }

            public override void OnConfigureFailed(CameraCaptureSession session)
            {
            }
        }
        public class CapCB : CameraCaptureSession.CaptureCallback
        {
            
        }
        public class ImageAvailableListener : Java.Lang.Object, ImageReader.IOnImageAvailableListener
        {
            public void OnImageAvailable(ImageReader reader)
            {
                var image = reader.AcquireLatestImage();

            }
        }
    }
    
}