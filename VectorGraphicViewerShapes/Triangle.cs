namespace VectorGraphicViewerShapesLib.Model
{
    public class Triangle : Shape
    {
        public string? a { get; set; }
        public string? b { get; set; }
        public string? c { get; set; }

        public override List<(double x, double y)> GetBoundingCorners()
        {
            return GetPoints();
        }

        public List<(double x , double y)> GetPoints()
        {
            return new()
            {
                  (GetDouble(a?.ToString()?.Split(";")[0]), GetDouble(a?.ToString()?.Split(";")[1])),
                  (GetDouble(b?.ToString()?.Split(";")[0]), GetDouble(b?.ToString()?.Split(";")[1])),
                  (GetDouble(c?.ToString()?.Split(";")[0]), GetDouble(c?.ToString()?.Split(";")[1])),
            };
           
        }
    }
}
