using System.IO;
using System.Text.Json;
using VectorGraphicViewer.Model.Patterns;
using VectorGraphicViewerShapesLib.Model;

namespace VectorGraphicViewer.Model.Repositories
{
    public class JsonRepository : IRepository<Shape>
    {
        public IEnumerable<Shape> GetShapes(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Shape>>(json, Deserializer.DeserializeOptions<Shape>(ResolveShapeType)) ?? new List<Shape>();
        }
        public Type ResolveShapeType(string type)
        {
            return type switch
            {
                "line" => typeof(Line),
                "circle" => typeof(Circle),
                "triangle" => typeof(Triangle),
                _ => throw new ArgumentException($"Unknown type: {type}")
            };
        }
    }
}
