using System;
using System.Collections.Generic;
using System.Text;

namespace UploadApp.Models
{
    public class SettingsDto
    {
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public bool IsState { get; set; }
    }
}
