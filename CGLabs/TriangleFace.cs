namespace CGLabs;

public class TriangleFace
{
  public Vertex Fpoint { get; }
  public Vertex Spoint { get; }
  public Vertex Thpoint { get; }

  public TriangleFace(Vertex fpoint, Vertex spoint, Vertex thpoint)
  {
    Fpoint = fpoint;
    Spoint = spoint;
    Thpoint = thpoint;
  }
}
