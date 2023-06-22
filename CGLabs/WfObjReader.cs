using System.Globalization;
using CGLabs.Objects;

namespace CGLabs;

public class WfObjReader
{
  public static TriangleFace[] ReadObjFile(byte[] fileContent)
  {
    var vertices = new List<Vertex>();
    var faces = new List<TriangleFace>();

    var lines = System.Text.Encoding.Default.GetString(fileContent).Split('\n');
    var vIndex = 1;

    foreach (var line in lines)
    {
      var parts = line.Split(" ");
      if (parts[0] == "v")
      {
        var x = float.Parse(parts[1], CultureInfo.InvariantCulture);
        var y = float.Parse(parts[2], CultureInfo.InvariantCulture);
        var z = float.Parse(parts[3], CultureInfo.InvariantCulture);

        vertices.Add(new Vertex(x, y, z, vIndex++));
      }
      else if (parts[0] == "f")
      {
        var fVertexIndex = int.Parse(parts[1].Split("//")[0]);
        var sVertexIndex = int.Parse(parts[2].Split("//")[0]);
        var thVertexIndex = int.Parse(parts[3].Split("//")[0]);

        var fVertex = vertices[fVertexIndex - 1];
        var sVertex = vertices[sVertexIndex - 1];
        var thVertex = vertices[thVertexIndex - 1];

        faces.Add(new TriangleFace(new List<Vertex> { fVertex, sVertex, thVertex }));
      }
    }

    return faces.ToArray();
  }
}
