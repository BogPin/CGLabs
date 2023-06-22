using System;

namespace CGLabs.Objects
{
  public class Camera
  {
    public Point At { get; set; }
    public Vector Direction { get; set; }
    public float Fov { get; set; }
    public int PixelsWidth { get; set; }
    public int PixelsHeight { get; set; }
    public float PixelsHalfWidth { get; set; }
    public float PixelsHalfHeight { get; set; }
    public float ScreenHalfWidth { get; set; }
    public float ScreenHalfHeight { get; set; }

    public Camera(Point at, Vector direction, float fov, int width, int height)
    {
      At = at;
      Direction = direction.Normalize();
      Fov = fov;
      PixelsWidth = width;
      PixelsHeight = height;
      PixelsHalfWidth = (float)width / 2F;
      PixelsHalfHeight = (float)height / 2F;
      ScreenHalfWidth = (float)Math.Tan(fov / 2F);
      ScreenHalfHeight = ScreenHalfWidth * height / width;
    }

    public Ray GetRay(int x, int y)
    {
      var normalizedDeltaX = ((float)x - PixelsHalfWidth) / PixelsHalfWidth;
      var normalizedDeltaY = (PixelsHalfHeight - (float)y) / PixelsHalfHeight;
      var vectorInScreenPlane = new Vector(
        normalizedDeltaX * ScreenHalfWidth,
        normalizedDeltaY * ScreenHalfHeight,
        0
      );
      return new Ray(At, (vectorInScreenPlane + Direction).Normalize());
    }
  }
}
