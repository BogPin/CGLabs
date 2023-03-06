using CGLabs.Interfaces;

namespace CGLabs.Objects
{
    using System;
    public class Disc : CGLabs.Interfaces.ITraceble
    {
        public float R;
        public Point Center;
        public Normal Normal;

        public Disc(float r, Point center, Normal normal)
        {
            R = r;
            Center = center;
            Normal = normal;
        }
        
        public bool Trace(Ray ray)
        {
            float ndDot = ray.Direction.DotProduct(Normal);
            if (Math.Abs(ndDot) < 1e-6) {
                return false;
            }
            float t = Normal.DotProduct(Center - ray.Origin) / ndDot;
            Point intersectionPoint = ray.Origin + t * ray.Direction;
            float icLength = (intersectionPoint - Center).GetLength();
            if (icLength > R) {
                return false;
            }

            return true;
        }
    }
}