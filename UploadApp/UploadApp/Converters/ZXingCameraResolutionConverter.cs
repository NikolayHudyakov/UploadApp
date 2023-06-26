using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;
using ZXing.Mobile;

namespace UploadApp.Converters
{
    class ZXingCameraResolutionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cameraResolution = (CameraResolution)value;
            return cameraResolution != null ? $"{cameraResolution.Width} * {cameraResolution.Height}" : string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] cameraResolution = value.ToString().Split("*");

            if (cameraResolution.Length == 2 && )
                return new CameraResolution();
            
            return new CameraResolution(){ Width = int.Parse(cameraResolution[0]), Height = int.Parse(cameraResolution[1]) };
        }
    }
}
