namespace CGLabs.Objects
{
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
        public bool Trace(Vector vector)
        {
            return false;
        }
    }
}