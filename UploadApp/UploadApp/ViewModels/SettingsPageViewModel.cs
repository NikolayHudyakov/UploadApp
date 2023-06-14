using System.Windows.Input;
using UploadApp.Models;
using UploadApp.Services;
using Xamarin.Forms;

namespace UploadApp.ViewModels
{
    internal class SettingsPageViewModel : BaseViewModel
    {
        private readonly ISettingsStorageService<SettingsDto> _settingsStorage;

        #region Field
        private SettingsDto _settingsDto;
        #endregion

        public SettingsPageViewModel(ISettingsStorageService<SettingsDto> settingsStorage) 
        {
            _settingsStorage = settingsStorage;
            GetSettingsAsync();
            SetSetingsCommand = new Command(SetSettingsAsync);
        }

        private async void GetSettingsAsync()
        {
            await _settingsStorage.GetSettingsAsync();
            SettingsDto = _settingsStorage.SettingsDto;
        }

        private async void SetSettingsAsync()
        {
            await _settingsStorage.SetSettingsAsync();
        }

        #region Property
        public SettingsDto SettingsDto
        {
            get => _settingsDto;
            private set => SetProperty(ref _settingsDto, value);
        }
        #endregion

        #region Command 
        public ICommand SetSetingsCommand { get; }
        #endregion
    }
}
