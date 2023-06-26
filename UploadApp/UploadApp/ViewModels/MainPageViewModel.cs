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
using ZXing;
using ZXing.Mobile;
using System.Linq;

namespace UploadApp.ViewModels
{
    internal class MainPageViewModel : BaseViewModel
    {
        private ISettingsStorageService<SettingsDto> _settingsStorage;

        #region Field
        private string _ipEndPont;
        #endregion
        private int _count = 0;
        public MainPageViewModel(ISettingsStorageService<SettingsDto> settingsStorage)
        {
            _settingsStorage = settingsStorage;

            GetSettingsAsync();

            
            ToStringCommand = new Command<Result>(ScanResult);


            ZXingScanningOptions = new MobileBarcodeScanningOptions();

            ZXingScanningOptions.CameraResolutionSelector = SetCameraResolution;
            

            
        }
        private CameraResolution SetCameraResolution(List<CameraResolution> availableResolutions) => availableResolutions[0];
        //{
        //    _settingsStorage.SettingsDto.ZXingCameraResolutions = availableResolutions;
        //    return _settingsStorage.SettingsDto.ZXingCurrentCameraResolution;
        //}
            
        private void ScanResult(Result result)
        {
            _count++;
            IpEndPont =$"{result.Text} *** {_count}";
        }
        
        private void GetPhoto(byte[] photo)
        {
            
        }

        private async void GetSettingsAsync()
        {
            await _settingsStorage.GetSettingsAsync();
            _settingsStorage.SettingsDto.TestList = new List<string> { "3434 * 2323", "34234 * 23223" };
        }
        
        #region Properties
        public string IpEndPont
        {
            get => _ipEndPont;
            set => SetProperty(ref _ipEndPont, value);
        }
        public MobileBarcodeScanningOptions ZXingScanningOptions { get; set; }
        #endregion

        #region Commands
        public ICommand ToStringCommand { get; private set; }
        #endregion
    }
}
