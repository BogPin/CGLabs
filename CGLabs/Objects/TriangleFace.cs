using CGLabs.Interfaces;

namespace CGLabs.Objects;

public class TriangleFace : ITraceable
{
  public List<Vertex> Vertices { get; set; }

  public TriangleFace(List<Vertex> vertices)
  {
    Vertices = vertices;
  }

  public bool isPointInside(Point point)
  {
    int vertexCount = Vertices.Count;
    bool isInside = false;

    for (int i = 0, j = vertexCount - 1; i < vertexCount; j = i++)
    {
      if (
        (Vertices[i].Y > point.Y) != (Vertices[j].Y > point.Y)
        && (
          point.X
          < (Vertices[j].X - Vertices[i].X)
            * (point.Y - Vertices[i].Y)
            / (Vertices[j].Y - Vertices[i].Y)
            + Vertices[i].X
        )
      )
      {
        isInside = !isInside;
      }
    }

    return isInside;
  }

  public Point? Trace(Ray ray)
  {
    var vertex0 = Vertices[0].ToVector();
    var vertex1 = Vertices[1].ToVector();
    var vertex2 = Vertices[2].ToVector();

    Vector edge1 = vertex1 - vertex0;
    Vector edge2 = vertex2 - vertex0;

    Vector pVector = Vector.Cross(ray.Direction, edge2);
    float determinant = Vector.Dot(edge1, pVector);

    if (Math.Abs(determinant) < float.Epsilon)
      return null;

    float inverseDeterminant = 1f / determinant;

    Vector tVector = ray.Origin.ToVector() - vertex0;
    float u = Vector.Dot(tVector, pVector) * inverseDeterminant;

    if (u < 0 || u > 1)
      return null;

    Vector qVector = Vector.Cross(tVector, edge1);
    float v = Vector.Dot(ray.Direction, qVector) * inverseDeterminant;

    if (v < 0 || u + v > 1)
      return null;

    float t = Vector.Dot(edge2, qVector) * inverseDeterminant;

    if (t < 0)
      return null;

    var intersectionPoint = ray.Origin.ToVector() + t * ray.Direction;
    return intersectionPoint.ToPoint();
  }

  public Vector GetPointNormal(Point intersectionPoint, Point rayOrigin)
  {
    var vertex0 = Vertices[0].ToVector();
    var vertex1 = Vertices[1].ToVector();
    var vertex2 = Vertices[2].ToVector();

    Vector edge1 = vertex1 - vertex0;
    Vector edge2 = vertex2 - vertex0;

    Vector pVector = Vector.Cross(edge1, edge2).Normalize();

    float dotPrd = (intersectionPoint - rayOrigin).DotProduct(pVector);
    return dotPrd < 0 ? -pVector : pVector;
  }

  public void Transform(float[,] transfMatrix)
  {
    Vertices = Vertices
      .Select(vertex =>
      {
        var pointMatr = new float[1, 4]
        {
          { vertex.X, vertex.Y, vertex.Z, 1 }
        };
        var res = Matrixes.MatrixMultiplication(pointMatr, transfMatrix);
        return new Vertex(res[0, 0], res[0, 1], res[0, 2], vertex.Index);
      })
      .ToList();
  }

  public Vertex GetCenter()
  {
    var x = Vertices.Sum(vertex => vertex.X);
    var y = Vertices.Sum(vertex => vertex.Y);
    var z = Vertices.Sum(vertex => vertex.Z);
    return new Vertex(x, y, z, -1);
  }

  public override string ToString()
  {
    return $"[{string.Join(", ", Vertices.Select(v => $"{{x: {v.X}, y: {v.Y}, z: {v.Z}}}"))}]";
  }
}
