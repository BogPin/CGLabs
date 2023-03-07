using System;
using CGLabs.Objects;

namespace CGLabs
{
    class Program
    {
        private const float width = 135, height = 35;
        private const float halfWidth = width / 2, halfHeight = height / 2;
        static void Main(string[] args)
        {
            float fovDeg = 60;
            var fovRad = (float)(fovDeg / 180 * Math.PI);
            var cam = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fovRad, width, height);
            var objects = new CGLabs.Interfaces.ITraceble[] {
                new Disc(1, new Point(3, 0, 10), new Normal(1, 0, 0)),
                new Sphere(1, new Point(0, 0, 10))
            };
            var light = new LightSource(1, -1, 1);
            for (var i = 0; i < height; i++) {
                for (var j = 0; j < width; j++) {
                    var ray = cam.GetRay((j - halfWidth) / halfWidth, (halfHeight - i) / halfHeight);
                    Point point = null;
                    Vector normal = null;
                    foreach (var obj in objects)
                    {
                        point = obj.Trace(ray);
                        if (point != null) {
                            normal = obj.GetPointNormal(point, ray.Origin);
                            break;
                        }
                    }
                    float brightness = 0;
                    if (point != null) {
                        brightness = light.DotProduct(normal);
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
