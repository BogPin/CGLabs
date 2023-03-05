namespace CGLabs.Objects
{
    public class Camera
    {
        private Point _at;
        private Vector _direction;
        private int _fov;

        public Camera(Point at, Vector direction, int fov)
        {
            _at = at;
            _direction = direction;
            _fov = fov;
        }
    }
}