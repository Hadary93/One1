using System.Globalization;
using System.Windows.Data;
using VectorGraphicViewerShapesLib.Model;

namespace VectorGraphicViewer.Model.Converters
{
    public class TriangleConverter : IValueConverter
    {
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(Triangle))
            {
                var triangle = (VectorGraphicViewerShapesLib.Model.Triangle)value;
                switch (parameter)
                {
                    case "Points":
                        var points = triangle.GetPoints();
                        return string.Join(" ", points.Select(p => $"{p.x},{-p.y}"));
                    case "Fill":
                        return triangle.filled ? triangle.GetFill() : null;
                    case "Stroke":
                        return triangle.GetColor();
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
