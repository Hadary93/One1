using System.Globalization;
using System.Windows.Data;
using VectorGraphicViewerShapesLib.Model;

namespace VectorGraphicViewer.Model.Converters
{
    public class CircleConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(Circle))
            {
                var circle = (VectorGraphicViewerShapesLib.Model.Circle)value;
                switch (parameter)
                {
                    case "Width":
                        return circle.radius/2; 
                    case "Height":
                        return circle.radius/2;
                    case "ShiftX":
                        return -circle.radius/4;
                    case "ShiftY":
                        return -circle.radius/4;
                    case "Fill":
                        return circle.filled ? circle.GetFill() : null;
                    case "Stroke":
                        return circle.GetColor();
                    default:
                        break;
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
