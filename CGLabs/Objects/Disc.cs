using CGLabs.Interfaces;

namespace CGLabs.Objects
{
    using System;
    public class Disc : CGLabs.Interfaces.ITraceble
    {
        public float R { get; set; }
        public Point Center { get; set; }
        public Normal Normal { get; set; }

        public Disc(float r, Point center, Normal normal)
        {
            R = r;
            Center = center;
            Normal = normal;
        }
        
        public Point Trace(Ray ray)
        {
            float ndDot = ray.Direction.DotProduct(Normal);
            if (Math.Abs(ndDot) < 1e-6) {
                return null;
            }
            float t = Normal.DotProduct(Center - ray.Origin) / ndDot;
            Point intersectionPoint = ray.Origin + t * ray.Direction;
            float icLength = (intersectionPoint - Center).GetLength();
            if (icLength > R) {
                return null;
            }
            return intersectionPoint;
        }

        public Vector GetPointNormal(Point intersectionPoint, Point rayOrigin)
        {
            float t = (intersectionPoint - rayOrigin).DotProduct(Normal);
            return t < 0 ? -Normal : Normal;
        }
    }
}