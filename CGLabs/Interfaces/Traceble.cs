using CGLabs.Objects;

namespace CGLabs.Interfaces
{
    public interface ITraceble
    {
        public Point Trace(Ray ray);
        public Vector GetPointNormal(Point intersectionPoint);
    }
}