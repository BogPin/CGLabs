namespace CGLabs;

public struct Pixel
{

  public int R { get; }
  public int G { get; }
  public int B { get; }

  public Pixel(int r, int g, int b)
  {
    R = r;
    G = g;
    B = b;
  }

  public int normalizeAndGetNumber(int maxValue)
  {
    int koef = 255 / maxValue;
    return ((R * koef) << 16) + ((G * koef) << 8) + B * koef;
  }
}
