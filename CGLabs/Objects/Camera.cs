using System;

namespace CGLabs.Objects
{
    public class Camera
    {
        public Point At { get; set; }
        public Vector Direction { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public float Fov { get; set; }
        public float CenterX { get; set; }
        public float CenterY { get; set; }

        public Camera(Point at, Vector direction, float fov, int width, int height)
        {
            At = at;
            Direction = width / 2 / (float)Math.Tan(fov / 2) * direction;
            Fov = fov;
            Width = width;
            Height = height;
            CenterX = width / 2;
            CenterY = height / 2;
        }

        public Ray GetRay(float x, float y)
        {
            return new Ray(At, Direction + new Vector(x - CenterX, CenterY - y, 0));
        }
    }
}