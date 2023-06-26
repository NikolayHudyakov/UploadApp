using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using UploadApp.Services;
using ZXing.Mobile;
using ZXing.OneD;

namespace UploadApp.Models
{
    public class SettingsDto
    {
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public bool IsState { get; set; }
        public List<CameraResolution> ZXingCameraResolutions { get; set; }
        public CameraResolution ZXingCurrentCameraResolution { get; set; }

        public List<string> TestList { get; set; }
       
    }
}
