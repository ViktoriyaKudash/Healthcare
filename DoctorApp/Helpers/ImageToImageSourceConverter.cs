using System;
using System.Drawing;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace DoctorApp
{
	public class ImageToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Bitmap)
            {
                var source = value as Bitmap;
				return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
						   source.GetHbitmap(),
						   IntPtr.Zero,
						   Int32Rect.Empty,
						   BitmapSizeOptions.FromEmptyOptions());
			}
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
