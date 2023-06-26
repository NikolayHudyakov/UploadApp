using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
            return cameraResolution != null ? $"{cameraResolution.Width} * {cameraResolution.Height}" : "0 * 0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] cameraResolution = value.ToString().Split("*");
            int width, height;
            if (cameraResolution.Length == 2 && int.TryParse(cameraResolution[0], out width) & int.TryParse(cameraResolution[1], out height))
                return new CameraResolution() { Width = width, Height = height };
            return new CameraResolution();
        }
    }

    class ZXingCameraResolutionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cameraResolution = (List<CameraResolution>)value;
            var d = cameraResolution != null ? cameraResolution.ConvertAll : new List<string>();

            return d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return new List<CameraResolution>();
        }
    }
}
