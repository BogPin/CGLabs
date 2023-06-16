namespace CGLabs;

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
}
