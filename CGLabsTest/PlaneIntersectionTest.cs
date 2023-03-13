using NUnit.Framework;
using CGLabs.Objects;
using FluentAssertions;

namespace CGLabsTest
{
    [TestFixture]
    public class PlaneIntersectionTest
    {
        private Plane MockPlane { get; set; } = null!;

        [SetUp]
        public void InitPlane()
        {
            MockPlane = new Plane(new Normal(-1, 0, 0), new Point(3, 0, 2));
        }

        [Test]
        public void InitiateIntersectableRayAndPlane_ReturnsIntersection()
        {
            Ray ray = new Ray(new Point(0F, 5F, 0F), new Vector(3F, 0F, 2F));
            Point actual = MockPlane.Trace(ray);
            Point expected = new Point(3F, 5F, 2F);
            actual.Should().BeEquivalentTo(expected, options => 
                                options.IncludingFields());
        }

        [Test]
        public void InitiateNotIntersectableRayAndSphere_RayIsPerpendicularToNormal_ReturnsNull()
        {
            Ray ray = new Ray(new Point(0F, 0F, 0F), new Vector(0F, 0F, 1F));
            Point actual = MockPlane.Trace(ray);
            Point expected = null;
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void InitiateNotIntersectableRayAndSphere_RayIsOpositeToNormal_ReturnsNull()
        {
            Ray ray = new Ray(new Point(0F, 5F, 0F), new Vector(-1F, 0F, 0F));
            Point actual = MockPlane.Trace(ray);
            Point expected = null;
            actual.Should().BeEquivalentTo(expected);
        }
    }
}