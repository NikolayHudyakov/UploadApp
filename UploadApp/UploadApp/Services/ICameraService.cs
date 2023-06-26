using System;
using System.Collections.Generic;
using System.Text;

namespace UploadApp.Services
{
    public interface ICameraService
    {
        public event PhotoEventHandler Photo;
        public void MakePhoto();
    }
    public delegate void PhotoEventHandler(byte[] photo);
}
