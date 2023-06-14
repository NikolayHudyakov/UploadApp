using System;
using System.Collections.Generic;
using System.Text;

namespace UploadApp.Services
{
    class TcpClientService : ITcpClientService
    {
        public string IpAddress { get ; set; }
        public string Port { get; set; }
    }
}
