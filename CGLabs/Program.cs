using System;
using CGLabs.Objects;

namespace CGLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = 135, height = 35;
            float fovDeg = 60;
            var fovRad = (float)(fovDeg / 180 * Math.PI);
            var camera = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fovRad, width, height);
            var light = new LightSource(1, -2, 1);
            var scene = new Scene(camera, light);
            scene.AddFigure(new Disc(1, new Point(4, 0, 10), new Normal(1, 0, 0)));
            scene.AddFigure(new Plane(new Normal(1, 1, 0), new Point(-1, 0, 0)));
            scene.AddFigure(new Sphere(1, new Point(2, 0, 10)));
            scene.AddFigure(new Sphere(0.5F, new Point(1, 0, 9)));
            scene.Render();
        }
    }
}
