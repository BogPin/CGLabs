using System;
using CGLabs.Objects;

namespace CGLabs
{
    class Program
    {
        private const int width = 80, height = 25;
        static void Main(string[] args)
        {
            float fovDeg = 60;
            var fovRad = (float)(fovDeg / 180 * Math.PI);
            var cam = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fovRad, width, height);
            var objects = new CGLabs.Interfaces.ITraceble[] {
                new Disc(2, new Point(1, 0, 5), new Normal(0, 0, 1))
            };
            var light = new LightSource(0, -1, 0);
            for (var i = 0; i < cam.Height; i++) {
                for (var j = 0; j < cam.Width; j++) {
                    var ray = cam.GetRay(j, i);
                    var traced = false;
                    foreach (var obj in objects)
                    {
                        if (obj.Trace(ray)) {
                            traced = true;
                            break;
                        }
                    }
                    float brightness = 0;
                    if (traced) {
                        var vec1 = (-ray.Direction).Normalize();
                        var vec2 = (-light).Normalize();
                        brightness = vec1.DotProduct(vec2);
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
