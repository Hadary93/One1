using System.Globalization;
using System.Windows.Data;

namespace VectorGraphicViewer.Model.Converters
{
    public class CenterContentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value != null)
            {
                double.TryParse(value.ToString(), out double result);

                return result/2;
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

      
    }
}
