namespace CGLabs.Objects
{
    using System;
    public class Plane : CGLabs.Interfaces.ITraceble
    {
        public Normal Normal { get; set; }
        public Point Point { get; set; }
        public Vector Vector { get; set; }

        public Plane(Normal normal, Point point, Vector vector)
        {
            Normal = normal;
            Point = point;
            Vector = vector;
        }
        
        public bool Trace(Ray ray)
        {
            float dn = ray.Direction.DotProduct(Normal);
            if (Math.Abs(dn) < 1e-6) {
                return false;
            }
            float oiLength = Normal.DotProduct(Point - ray.Origin) / dn;
            if (oiLength < 0.0) {
                return false;
            }

            return true;
        }
    }
}