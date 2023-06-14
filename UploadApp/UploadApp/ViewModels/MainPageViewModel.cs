using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Windows.Input;
using UploadApp.Models;
using Xamarin.Forms;
using Xamarin.Essentials;
using UploadApp.Services;
using System.IO;
using System.Threading.Tasks;
using Emgu;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Util;
using Emgu.CV.Structure;

namespace UploadApp.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        private ITcpClientService _tcpClientModel;
        private ISettingsStorageService<SettingsDto> _settingsStorage;

        #region Field
        private string _ipEndPont;
        private ImageSource _imageSource;
        #endregion

        public MainPageViewModel(ITcpClientService tcpClientModel, ISettingsStorageService<SettingsDto> settingsStorage)
        {
            _tcpClientModel = tcpClientModel;
            _settingsStorage = settingsStorage;
            GetSettingsAsync();
            ToStringCommand = new Command(GetPhoto);
            
        }

        private async void GetSettingsAsync()
        {
            await _settingsStorage.GetSettingsAsync();
        }
        
        private async void GetPhoto()
        {
            await Task.Delay(100);
        }

        private void VideoCapture_ImageGrabbed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Properties
        public string IpEndPont
        {
            get => _ipEndPont;
            set => SetProperty(ref _ipEndPont, value);
        }
        public ImageSource ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }
        #endregion

        #region Commands
        public ICommand ToStringCommand { get; private set; }
        #endregion
    }
}
