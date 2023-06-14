using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UploadApp.Models;

namespace UploadApp.Services
{
    public interface ISettingsStorageService<T>
    {
        T SettingsDto { get; }

        Task GetSettingsAsync();

        Task SetSettingsAsync();
    }
}
