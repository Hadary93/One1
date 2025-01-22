using System.Globalization;

namespace VectorGraphicViewerShapesLib.Model
{
    public abstract class Shape
    {
        public string? type { get; set; }
        public string? color { get; set; }
        public bool filled { get; set; }
        public string GetColor()
        {
            var parts = color?.Split(';') ?? new string[4] { "0", "0", "0", "0" };

            int alpha = int.Parse(parts[0].Trim());
            int red = int.Parse(parts[1].Trim());
            int green = int.Parse(parts[2].Trim());
            int blue = int.Parse(parts[3].Trim());

            return $"#{alpha:X2}{red:X2}{green:X2}{blue:X2}";

        }

        public double GetDouble(string? value)
        {
            return double.Parse(value?.Replace(",", ".") ?? string.Empty, CultureInfo.InvariantCulture);
        }

        public string GetFill()
        {
            return GetColor();
        }

        public abstract List<(double x,double y)> GetBoundingCorners();
    }
}
