using NUnit.Framework;
using CGLabs.Objects;
using FluentAssertions;
using System;

namespace CGLabsTest
{
    [TestFixture]
    public class SceneTest
    {
        [Test]
        public void ClosestObjectTest()
        {
            int width = 135, height = 35;
            float fovDeg = 60;
            var fovRad = (float)(fovDeg / 180 * Math.PI);
            var camera = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fovRad, width, height);
            var light = new LightSource(0, -1, 0);
            var scene = new Scene(camera, light);
            scene.AddFigure(new Sphere(1, new Point(0, 0, 12)));
            scene.AddFigure(new Disc(1, new Point(0, 0, 8), new Normal(0, 1, -1)));

            var normal = scene.TracePixel(70, 25);

            normal.Should().BeEquivalentTo(new Vector(0, -1, 1), options => options.ExcludingMissingMembers());
        }
    }
}