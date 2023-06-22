using CGLabs.Objects;
using FluentAssertions;

namespace CGLabsTest
{
  [TestFixture]
  public class VectorTest
  {
    [Test]
    public void DotProductTest()
    {
      Vector vectorA = new Vector(1, 1, 1);
      Vector vectorB = new Vector(2, 5, 7);
      var prod = vectorA.DotProduct(vectorB);
      prod.Should().Be(14F);
    }

    [Test]
    public void GetLengthTest()
    {
      Vector vector = new Vector(3, 4, 0);
      var length = vector.GetLength();
      length.Should().Be(5F);
    }

    [Test]
    public void NormalizeTest()
    {
      Vector vector = new Vector(3, 0, 0);
      Vector normalized = vector.Normalize();
      new Vector(1, 0, 0)
        .Should()
        .BeEquivalentTo(normalized, options => options.ExcludingMissingMembers());
    }

    [Test]
    public void ToStringTest()
    {
      Vector vector = new Vector(3, 10, 23);
      var strVector = vector.ToString();
      strVector.Should().Be("(3, 10, 23)");
    }

    [Test]
    public void OperatorMinTest()
    {
      Vector vectorA = new Vector(1, 2, 3);
      Vector vectorB = new Vector(5, 3, 7);
      Vector minVectorA = -vectorA;
      Vector aMinB = vectorA - vectorB;
      new Vector(-1, -2, -3)
        .Should()
        .BeEquivalentTo(minVectorA, options => options.ExcludingMissingMembers());
      new Vector(-4, -1, -4)
        .Should()
        .BeEquivalentTo(aMinB, options => options.ExcludingMissingMembers());
    }

    [Test]
    public void OperatorPlusTest()
    {
      Vector vectorA = new Vector(1, 2, 3);
      Vector vectorB = new Vector(5, 3, 7);
      Vector aPlusB = vectorA + vectorB;
      new Vector(6, 5, 10)
        .Should()
        .BeEquivalentTo(aPlusB, options => options.ExcludingMissingMembers());
    }

    [Test]
    public void OperotorMultiplyTest()
    {
      Vector vector = new Vector(2, 6, -1);
      var res = 8 * vector;
      new Vector(16, 48, -8)
        .Should()
        .BeEquivalentTo(res, options => options.ExcludingMissingMembers());
    }
  }
}
