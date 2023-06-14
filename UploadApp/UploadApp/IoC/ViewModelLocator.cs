using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using UploadApp.ViewModels;

namespace UploadApp.IoC
{
    internal class ViewModelLocator
    {
        public MainPageViewModel MainPageViewModel => ServiceLocator.Current.GetInstance<MainPageViewModel>();
        public SettingsPageViewModel SettingsPageViewModel => ServiceLocator.Current.GetInstance<SettingsPageViewModel>();
    }
}
