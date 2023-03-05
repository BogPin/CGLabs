using CGLabs.Interfaces;

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
        
        public Point Trace(Vector vector)
        {
            return null;
        }
    }
}