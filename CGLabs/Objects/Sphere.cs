namespace CGLabs.Objects
{
    using System;
    public class Sphere : CGLabs.Interfaces.ITraceble
    {
        public float R { get; set; }
        public Point Center { get; set; }

        public Sphere(float r, Point center)
        {
            R = r;
            Center = center;
        }
        
        public Point Trace(Ray ray)
        {
            Vector rd = ray.Direction.Normalize();
            float t = (Center - ray.Origin).DotProduct(rd);
            Point p = ray.Origin + t * rd;
            float y = (Center - p).GetLength();
            if (y > R) {
                return null;
            }
            float x = (float) Math.Sqrt(R * R - y * y);
            Point intersectionPoint = ray.Origin + (t - x) * rd;
            return intersectionPoint;
        }

        public Vector GetPointNormal(Point intersectionPoint, Point rayOrigin)
        {
            return (intersectionPoint - Center).Normalize();
        }  
    }
}