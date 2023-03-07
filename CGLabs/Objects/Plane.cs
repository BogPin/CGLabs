namespace CGLabs.Objects
{
    using System;
    public class Plane : CGLabs.Interfaces.ITraceble
    {
        public Normal Normal { get; set; }
        public Point Point { get; set; }

        public Plane(Normal normal, Point point)
        {
            Normal = normal;
            Point = point;
        }
        
        public Point Trace(Ray ray)
        {
            float dn = ray.Direction.DotProduct(Normal);
            if (Math.Abs(dn) < 1e-6) {
                return null;
            }
            float t = Normal.DotProduct(Point - ray.Origin) / dn;
            Point intersectionPoint = ray.Origin + t * ray.Direction;
            if (t < 0.0) {
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