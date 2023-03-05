namespace CGLabs.Objects
{
    public class Plate  : CGLabs.Interfaces.ITraceble
    {
        public Normal Normal;
        public Point Point;
        public Vector Vector;
        public Plate(Normal normal, Point point, Vector vector)
        {
            Normal = normal;
            Point = point;
            Vector = vector;
        }
        public bool Trace(Vector vector)
        {
            return false;
        }
    }
}