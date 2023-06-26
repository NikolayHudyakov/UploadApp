using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UploadApp.Models;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace UploadApp.Services
{
    public class SettingsStorageService : ISettingsStorageService<SettingsDto>
    {
        public SettingsDto SettingsDto { get; private set; }

        public async Task GetSettingsAsync() =>
             await Task.Run(() => SettingsDto ??= JsonConvert.DeserializeObject<SettingsDto>(Preferences.Get(nameof(SettingsDto), string.Empty)) ?? new SettingsDto());
        
        public async Task SetSettingsAsync() =>
             await Task.Run(() => Preferences.Set(nameof(SettingsDto), JsonConvert.SerializeObject(SettingsDto)));
    }
}
