namespace VectorGraphicViewer.Model.Extensions
{
    public static class ListExtensions
    {
        public static (double width, double height) GetBoundingBoxSize(this IEnumerable<(double, double)> points)
        {
            if (points == null || points.Count() == 0)
                throw new ArgumentException("The list of points cannot be null or empty.", nameof(points));


            double minX = points.Min(p => p.Item1);
            double maxX = points.Max(p => p.Item1);
            double minY = points.Min(p => p.Item2);
            double maxY = points.Max(p => p.Item2);


            double width = maxX - minX;
            double height = maxY - minY;

            return (width, height);
        }
    }
}
