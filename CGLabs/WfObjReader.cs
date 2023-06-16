namespace CGLabs;

public class WfObjReader
{
  public static List<TriangleFace> readObjFile(string pathToFile)
  {
    List<Vertex> vertices = new List<Vertex>();
    List<TriangleFace> faces = new List<TriangleFace>();

    string[] lines = File.ReadAllLines(pathToFile);
    int vIndex = 1;

    foreach (string line in lines)
    {
      string[] parts = line.Split(" ");

      if (parts[0] == "v")
      {
        float x = float.Parse(parts[1]);
        float y = float.Parse(parts[2]);
        float z = float.Parse(parts[3]);

        vertices.Add(new Vertex(x, y, z, vIndex));
        vIndex++;
      }
      else if (parts[0] == "f")
      {
        int fVertexIndex = int.Parse(parts[1]);
        int sVertexIndex = int.Parse(parts[2]);
        int thVertexIndex = int.Parse(parts[3]);

        Vertex fVertex = vertices[fVertexIndex - 1];
        Vertex sVertex = vertices[sVertexIndex - 1];
        Vertex thVertex = vertices[thVertexIndex - 1];

        faces.Add(new TriangleFace(fVertex, sVertex, thVertex));
      }
    }

    return faces;
  }
}
