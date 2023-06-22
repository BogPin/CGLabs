namespace CGLabs.Objects
{
  public class Point
  {
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Point(float x, float y, float z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public static Point operator +(Point point, Vector vector)
    {
      return new Point(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);
    }

    public static Vector operator -(Point a, Point b)
    {
      return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public Vector ToVector()
    {
      return new Vector(X, Y, Z);
    }
  }
}
