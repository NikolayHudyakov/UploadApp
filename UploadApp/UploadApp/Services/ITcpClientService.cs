using System;
using System.Collections.Generic;
using System.Text;

namespace UploadApp.Services
{
    public interface ITcpClientService
    {
        string IpAddress { get; set; }
        string Port { get; set; }
    }
}
