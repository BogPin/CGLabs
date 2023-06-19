using CGLabs.Interfaces;
using CGLabs.Objects;

namespace CGLabs;

public class TriangleFace : ITraceable
{
  public List<Vertex> Vertices { get; }

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

  // public Point Trace(Ray ray)
  // {
  //     double closestDistance = double.MaxValue;
  //     Point closestIntersection = null;

  //     for (int i = 0; i < Vertices.Count; i++)
  //     {

  //     }
  // }

  public Vector GetPointNormal(Point intersectionPoint, Point rayOrigin)
  {
    throw new NotImplementedException();
  }
}
