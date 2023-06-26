using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Media;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using Java.Lang;
using System.IO;
using System.Threading.Tasks;
using UploadApp.Services;
using Xamarin.Essentials;
using File = Java.IO.File;

namespace UploadApp.Droid.Services.Camera
{
    public class CameraService : ICameraService
    {
        public event PhotoEventHandler Photo;

        public void MakePhoto()
        {
            if (CameraViewServiceRenderer.Camera != null)
            {
                CameraViewServiceRenderer.Camera.Photo += GetPhoto;
                CameraViewServiceRenderer.Camera.LockFocus();
            }
        }

        private void GetPhoto(object sender, byte[] imgSource)
        {
            Photo?.Invoke(imgSource);
            CameraViewServiceRenderer.Camera.Photo -= GetPhoto;
        }

        public async Task<bool> SavePhotoAsync(byte[] data, string folder, string filename)
        {
            try
            {
                File picturesDirectory = Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures);
                File folderDirectory = picturesDirectory;

                if (!string.IsNullOrEmpty(folder))
                {
                    folderDirectory = new File(picturesDirectory, folder);
                    folderDirectory.Mkdirs();
                }

                using (File bitmapFile = new File(folderDirectory, filename))
                {
                    bitmapFile.CreateNewFile();

                    using (FileOutputStream outputStream = new FileOutputStream(bitmapFile))
                    {
                        await outputStream.WriteAsync(data);
                    }

                    // Make sure it shows up in the Photos gallery promptly.
                    MediaScannerConnection.ScanFile(MainActivity.Instance,
                                                    new string[] { bitmapFile.Path },
                                                    new string[] { "image/png", "image/jpeg" }, null);
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}