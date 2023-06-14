using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using CommonServiceLocator;
using UploadApp.ViewModels;
using Xamarin.Forms.Xaml;

namespace UploadApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CameraPreview.PictureFinished += OnPictureFinished;
        }
        void OnCameraClicked(object sender, EventArgs e)
        {
            CameraPreview.CameraClick.Execute(null);
        }

        private void OnPictureFinished()
        {
            DisplayAlert("Confirm", "Picture Taken", "", "Ok");
        }
    }
}
