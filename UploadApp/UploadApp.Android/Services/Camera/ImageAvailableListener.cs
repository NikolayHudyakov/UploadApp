using Android.App;
using Android.Content;
using Android.Media;
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
    internal class ImageAvailableListener : Java.Lang.Object, ImageReader.IOnImageAvailableListener
    {
        public event EventHandler<byte[]> Photo;

        public void OnImageAvailable(ImageReader reader)
        {
            Image image = null;

            try
            {
                image = reader.AcquireLatestImage();
                var buffer = image.GetPlanes()[0].Buffer;
                var imageData = new byte[buffer.Capacity()];
                buffer.Get(imageData);

                Photo?.Invoke(this, imageData);
            }
            catch (Exception ex)
            {
                // ignored
            }
            finally
            {
                image?.Close();
            }
        }
    }
}