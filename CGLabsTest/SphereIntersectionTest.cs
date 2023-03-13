using NUnit.Framework;
using CGLabs.Objects;
using FluentAssertions;

namespace CGLabsTest
{
    [TestFixture]
    public class SphereIntersectionTest
    {
        private Sphere MockSphere { get; set; } = null!;

        [SetUp]
        public void InitSphere()
        {
            MockSphere = new Sphere(2F, new Point(3, 5, 0));
        }

        [Test]
        public void InitiateIntersectableRayAndSphere_ReturnsIntersection()
        {
            Ray ray = new Ray(new Point(0F, 5F, 0F), new Vector(3F, 0F, 0F));
            Point actual = MockSphere.Trace(ray);
            Point expected = new Point(1F, 5F, 0F);
            actual.Should().BeEquivalentTo(expected, options => 
                                options.IncludingFields());
        }

        [Test]
        public void InitiateNotIntersectableRayAndSphere_ReturnsNull()
        {
            Ray ray = new Ray(new Point(0, 0, 0), new Vector(-0.48F, 7.77F, 0F));
            Point actual = MockSphere.Trace(ray);
            Point expected = null;
            actual.Should().BeEquivalentTo(expected);
        }
    }
}