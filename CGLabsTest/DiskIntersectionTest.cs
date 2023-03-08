using NUnit.Framework;
using CGLabs.Objects;
using FluentAssertions;

namespace CGLabsTest
{
    [TestFixture]
    public class DiskIntersectionTest
    {
        private Disc MockDisc { get; set; } = null!;

        [SetUp]
        public void InitDisc()
        {
            MockDisc = new Disc(2F, new Point(4F, -4F, 0F), new Normal(-1F, 0F, 0F));
        }

        [Test]
        public void InitiateIntersectableRayAndDisc_ReturnsIntersection()
        {
            Ray ray = new Ray(new Point(0F, -4F, 0F), new Vector(1F, 0F, 0F));
            Point expected = MockDisc.Trace(ray);
            Point actual = new Point(4F, -4F, 0F);
            expected.Should().BeEquivalentTo(actual, options => 
                                options.IncludingFields());
        }

        [Test]
        public void InitiateNotIntersectableRayAndDisc_RayIsPerpendicularToNormal_ReturnsNull()
        {
            Ray ray = new Ray(new Point(0F, 0F, 0F), new Vector(0F, 0F, 1F));
            Point expected = MockDisc.Trace(ray);
            Point actual = null;
            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void InitiateNotIntersectableRayAndSphere_LengthFromCenterToRayIsBiggerThatRadius_ReturnsNull()
        {
            Ray ray = new Ray(new Point(0F, -4F, 0F), new Vector(1F, 0F, 1F));
            Point expected = MockDisc.Trace(ray);
            Point actual = null;
            expected.Should().BeEquivalentTo(actual);
        }
    }
}