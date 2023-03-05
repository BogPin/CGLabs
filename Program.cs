using System;
using CGLabs.Objects;

namespace CGLabs
{
    class Program
    {
        private const int width = 20, height = 20;
        static void Main(string[] args)
        {
            var fov = (float)(60 / 180 * Math.PI);
            var cam = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fov, width, height);
            var objects = new CGLabs.Interfaces.ITraceble[] {
                new Sphere(3, new Point(0, 0, 2))
            };
            var light = new LightSource(0, -1, 0);
            for (var i = 0; i < cam.Height; i++) {
                for (var j = 0; j < cam.Width; j++) {
                    var vector = cam.GetVector(j, i);
                    Point point = null;
                    foreach (var obj in objects)
                    {
                        point = obj.Trace(vector);
                        if (point != null) break;
                    }
                    float brightness = 0;
                    if (point != null) {
                        var vec1 = cam.At - point;
                        brightness = vec1.Normalize().DotProduct(-light.Normalize());
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
