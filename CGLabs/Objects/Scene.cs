using System;
using System.Collections.Generic;
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

    public Scene(Camera camera, LightSource lightSource, List<ITraceable> figures)
    {
      Camera = camera;
      LightSource = lightSource;
      Figures = figures;
    }

    public int AddFigure(ITraceable figure)
    {
      Figures.Add(figure);
      return Figures.Count;
    }

    public Vector TracePixel(int x, int y)
    {
      var ray = Camera.GetRay(x, y);
      Vector closestNormal = null;
      var shortestDistance = float.MaxValue;
      foreach (var obj in Figures)
      {
        var point = obj.Trace(ray);
        if (point != null)
        {
          var distance = (point - ray.Origin).GetLength();
          if (distance < shortestDistance)
          {
            closestNormal = obj.GetPointNormal(point, ray.Origin);
            shortestDistance = distance;
          }
        }
      }
      return closestNormal;
    }

    public void Render()
    {
      for (var i = 0; i < Camera.PixelsHeight; i++)
      {
        for (var j = 0; j < Camera.PixelsWidth; j++)
        {
          var closestNormal = TracePixel(j, i);
          float brightness = 0;
          if (closestNormal != null)
          {
            brightness += LightSource.DotProduct(closestNormal);
          }
          char ch;
          if (brightness <= 0)
          {
            ch = ' ';
          }
          else if (brightness < 0.2)
          {
            ch = '.';
          }
          else if (brightness < 0.5)
          {
            ch = '*';
          }
          else if (brightness < 0.8)
          {
            ch = '0';
          }
          else
          {
            ch = '#';
          }
          Console.Write(ch);
        }
        Console.WriteLine();
      }
    }
  }
}
