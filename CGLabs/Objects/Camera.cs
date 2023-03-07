using System;

namespace CGLabs.Objects
{
    public class Camera
    {
        public Point At { get; set; }
        public Vector Direction { get; set; }
        public float Fov { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public float ScreenHalfWidth { get; set; }
        public float ScreenHalfHeight { get; set; }

        public Camera(Point at, Vector direction, float fov, float width, float height)
        {
            At = at;
            Direction = direction.Normalize();
            Fov = fov;
            ScreenHalfWidth = (float)Math.Tan(fov / 2);
            ScreenHalfHeight = ScreenHalfWidth * height / width;
        }

        public Ray GetRay(float normalizedDeltaX, float normalizedDeltaY)
        {
            return new Ray(
                At,
                new Vector(
                    normalizedDeltaX * ScreenHalfWidth,
                    normalizedDeltaY * ScreenHalfHeight,
                    0
                ) + Direction
            );
        }
    }
}