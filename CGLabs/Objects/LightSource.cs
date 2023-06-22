namespace CGLabs.Objects
{
  public class LightSource : Vector
  {
    public LightSource(float x, float y, float z)
      : base(x, y, z) { }

    public new LightSource Normalize()
    {
      var len = (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
      return new LightSource(X / len, Y / len, Z / len);
    }
  }
}
