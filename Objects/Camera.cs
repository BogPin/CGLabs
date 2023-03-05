using System;

namespace CGLabs.Objects
{
    public class Camera
    {
        public Point At;
        private Vector _direction;
        public int Width, Height;
        private float _fov, _centerX, _centerY;

        public Camera(Point at, Vector direction, float fov, int width, int height)
        {
            At = at;
            _direction = width / 2 / (float)Math.Tan(_fov / 2) * direction;
            _fov = fov;
            Width = width;
            Height = height;
            _centerX = width / 2;
            _centerY = height / 2;
        }

        public Vector GetVector(float x, float y)
        {
            return _direction + new Vector(x - _centerX, _centerY - y, 0);
        }
    }
}