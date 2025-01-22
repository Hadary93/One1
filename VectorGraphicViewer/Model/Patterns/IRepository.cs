namespace VectorGraphicViewer.Model.Patterns
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetShapes(string filePath);
    }
}
