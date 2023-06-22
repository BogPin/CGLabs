namespace CGLabs.Objects;

public class Vertex
{
  public float X { get; }
  public float Y { get; }
  public float Z { get; }
  public int Index { get; }

  public Vertex(float x, float y, float z, int index)
  {
    X = x;
    Y = y;
    Z = z;
    Index = index;
  }

  public Point ToPoint()
  {
    return new Point(X, Y, Z);
  }

  public Vector ToVector()
  {
    return new Vector(X, Y, Z);
  }

  public override string ToString()
  {
    return $"{{x: {X}, y: {Y}, z: {Z}}}";
  }
}
