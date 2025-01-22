using System.Globalization;
using System.Windows.Data;
using Line = VectorGraphicViewerShapesLib.Model.Line;

namespace VectorGraphicViewer.Model.Converters
{
    public class LineConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           
            if (value != null && value.GetType() == typeof(Line))
            {
                var line = (VectorGraphicViewerShapesLib.Model.Line)value;
                switch (parameter)
                {
                    case "X1":
                        return line.GetX1();
                    case "Y1":
                        return line.GetY1();
                    case "X2":
                        return line.GetX2();
                    case "Y2":
                        return line.GetY2();
                    case "Stroke":
                        return line.GetColor();
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
