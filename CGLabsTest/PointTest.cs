using CGLabs.Objects;
using FluentAssertions;
using NUnit.Framework;

namespace CGLabsTest
{
    public class PointTest
    {
        [Test]
        public void OperatorPlusTest()
        {
            Vector vector = new Vector(3, 2, 6);
            Point point = new Point(5, 2, 6);
            var res = point + vector;
            new Point(8, 4,12).Should().BeEquivalentTo(res, options => 
                options.ExcludingMissingMembers());
        }
        
        [Test]
        public void OperatorMinusTest()
        {
            Point pointA = new Point(5, 7, -4);
            Point pointB = new Point(10, -4, -9);
            var res = pointA - pointB;
            new Vector(-5, 11, 5).Should().BeEquivalentTo(res, options => 
                options.ExcludingMissingMembers());
        }
    }
}