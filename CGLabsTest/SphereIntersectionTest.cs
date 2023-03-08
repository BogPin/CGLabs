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
        public void Init()
        {
            MockSphere = new Sphere(2F, new Point(3, 5, 0));
        }

        [Test]
        public void InitiateIntersectableRayAndSphere_ReturnsIntersection()
        {
            Ray ray = new Ray(new Point(0F, 5F, 0F), new Vector(3F, 0F, 0F));
            Point expected = MockSphere.Trace(ray);
            Point actual = new Point(1F, 5F, 0F);
            expected.Should().BeEquivalentTo(actual, options => 
                                options.IncludingFields());
        }

        [Test]
        public void InitiateNotIntersectableRayAndSphere_ReturnsNull()
        {
            Ray ray = new Ray(new Point(0, 0, 0), new Vector(-0.48F, 7.77F, 0F));
            Point expected = MockSphere.Trace(ray);
            Point actual = null;
            expected.Should().BeEquivalentTo(actual);
        }
    }
}