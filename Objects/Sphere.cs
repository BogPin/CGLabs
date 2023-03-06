namespace CGLabs.Objects
{
    using System;
    public class Sphere : CGLabs.Interfaces.ITraceble
    {
        public float R;
        public Point Center;

        public Sphere(float r, Point center)
        {
            R = r;
            Center = center;
        }
        
        public bool Trace(Ray ray)
        {
            Vector oc = Center - ray.Origin;
            float projectionLength = oc.DotProduct(ray.Direction);
            if (projectionLength < 0.0) {
                return false;
            }
            float ocLength = oc.GetLength();
            float d = (projectionLength * projectionLength) - (ocLength * ocLength);
            float r2 = R * R;
            if (d > r2) {
                return false;
            }

            return true;
        }
    }
}