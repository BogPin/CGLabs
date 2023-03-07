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
            Vector oc = ray.Origin - Center;
            float a = ray.Direction.DotProduct(ray.Direction);
            float b = ((float)(oc.DotProduct(ray.Direction) * 2.0));
            float c = oc.DotProduct(oc) - R * R;
            float discr = b * b - 4 * a * c;
            return discr > 0;
        }

        public Vector GetPointNormal(Point intersectionPoint)
        {
            throw new NotImplementedException();
        }  
    }
}