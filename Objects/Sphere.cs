namespace CGLabs.Objects
{
    public class Sphere : CGLabs.Interfaces.ITraceble
    {
        public float R;
        public Point Center;

        public Sphere(float r, Point center)
        {
            R = r;
            Center = center;
        }
        
        public Point Trace(Vector vector)
        {
            return null;
        }
    }
}