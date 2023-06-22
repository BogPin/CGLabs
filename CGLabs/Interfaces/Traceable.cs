using CGLabs.Objects;

namespace CGLabs.Interfaces
{
  public interface ITraceable
  {
    public Point? Trace(Ray ray);
    public Vector GetPointNormal(Point intersectionPoint, Point rayOrigin);
  }
}
