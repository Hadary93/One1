namespace VectorGraphicViewerShapesLib.Model
{
    public class Circle : Shape
    {
        public string? center { get; set; }
        public double radius { get; set; }

        public override List<(double, double)> GetBoundingCorners()
        {
            var centerCoords = center?.Split(";");
            double centerX = GetDouble(centerCoords?[0]);
            double centerY = GetDouble(centerCoords?[1]);

            double topLeftX = centerX - radius;
            double topLeftY = centerY - radius;
            double topRightX = centerX + radius;
            double topRightY = centerY - radius;
            double bottomLeftX = centerX - radius;
            double bottomLeftY = centerY + radius;
            double bottomRightX = centerX + radius;
            double bottomRightY = centerY + radius;

            var corners = new List<(double, double)>
            {
                (topLeftX, topLeftY),
                (topRightX, topRightY),
                (bottomLeftX, bottomLeftY),
                (bottomRightX, bottomRightY)
            };

            return corners;
        }
    }
}
   
