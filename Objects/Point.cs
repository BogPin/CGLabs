namespace CGLabs.Objects
{
    public class Point
    {
        public float X, Y, Z;
        
        public Point(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        
        public static Vector operator -(Point a, Point b)
        {
            return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
    }
}