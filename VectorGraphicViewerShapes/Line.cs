namespace VectorGraphicViewerShapesLib.Model
{
    public class Line : Shape
    {
        public string? a { get; set; }
        public string? b { get; set; }

        public double GetX1()
        {
            return GetDouble(a?.ToString()?.Split(";")[0]);
        }
        public double GetY1()
        {
            return  - GetDouble(a?.ToString()?.Split(";")[1]); // -ve cartesian coordiantes
        }
        public double GetX2()
        {
            return GetDouble(b?.ToString()?.Split(";")[0]);
        }
        public double GetY2()
        {
            return - GetDouble(b?.ToString()?.Split(";")[1]); // -ve cartesian coordiantes
        }

        public List<(double x, double y)> GetPoints()
        {
            return new List<(double x, double y)>() {(GetX1(),GetY1()),(GetX2(),GetY2())};
        }

        public override List<(double x, double y)> GetBoundingCorners()
        {
            return GetPoints();
        }
    }
}
