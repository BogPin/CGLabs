using CGLabs.Interfaces;

namespace CGLabs.Objects
{
  public class Scene
  {
    public Camera Camera { get; set; }
    public LightSource LightSource { get; set; }
    public List<ITraceable> Figures { get; set; }

    public Scene(Camera camera, LightSource lightSource)
    {
      Camera = camera;
      LightSource = lightSource;
      Figures = new List<ITraceable>();
    }

    public Scene(Camera camera, LightSource lightSource, IEnumerable<ITraceable> figures)
    {
      Camera = camera;
      LightSource = lightSource;
      Figures = new List<ITraceable>(figures);
    }

    public int AddFigure(ITraceable figure)
    {
      Figures.Add(figure);
      return Figures.Count;
    }

    public int AddFigures(IEnumerable<ITraceable> figures)
    {
      Figures = Figures.Concat(figures).ToList();
      return Figures.Count;
    }

    public (Point?, Vector?) TracePixel(int x, int y)
    {
      var ray = Camera.GetRay(x, y);
      Point? closestIntersection = null;
      Vector? normal = null;
      var shortestDistance = float.MaxValue;
      foreach (var obj in Figures)
      {
        var point = obj.Trace(ray);
        if (point != null)
        {
          var distance = (point - ray.Origin).GetLength();
          if (distance < shortestDistance)
          {
            closestIntersection = point;
            normal = obj.GetPointNormal(point, ray.Origin);
            shortestDistance = distance;
          }
        }
      }
      return (closestIntersection, normal);
    }

    public Point? TracePixelFirst(Ray ray)
    {
      foreach (var obj in Figures)
      {
        var point = obj.Trace(ray);
        if (point != null)
        {
          var distToIntersection = (point - ray.Origin).GetLength();
          if (distToIntersection > 0.00001)
            return point;
        }
      }
      return null;
    }

    public byte[] Render(IImageWriter writer, int maxColorValue)
    {
      var pixels = new Pixel[Camera.PixelsHeight, Camera.PixelsWidth];
      for (var i = 0; i < Camera.PixelsHeight; i++)
      {
        for (var j = 0; j < Camera.PixelsWidth; j++)
        {
          var pixelBrightness = 0f;
          var (point, normal) = TracePixel(j, i);
          if (point != null && normal != null)
          {
            var pointToLightRay = new Ray(point, -LightSource);
            var intersection = TracePixelFirst(pointToLightRay);
            if (intersection == null)
              pixelBrightness = LightSource.DotProduct(normal);
          }
          var val = (byte)Math.Round(pixelBrightness * 255, MidpointRounding.AwayFromZero);
          pixels[i, j] = new Pixel(val, val, val);
        }
      }
      return writer.ImageToBytes(pixels, maxColorValue);
    }
  }
}
