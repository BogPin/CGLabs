using System.Text;
using CGLabs;
using PpmReaderNS;

namespace CGLabsTest;

public class TestReader
{
  [Test]
  public void PpmToPixels_ReturnsCorrectPixelArray()
  {
    // Arrange
    byte[] fileData = Encoding.ASCII.GetBytes(
      "P3\n2 2\n15\n15 0 0\t0 15 0\t\n0 0 15\t15 15 15\t\n"
    );
    PpmReader ppmReader = new PpmReader();

    // Act
    Pixel[,] result = ppmReader.ReadImage(fileData);

    // Assert
    Pixel[,] expected = new Pixel[,]
    {
      { new Pixel(255, 0, 0), new Pixel(0, 255, 0) },
      { new Pixel(0, 0, 255), new Pixel(255, 255, 255) }
    };
    Assert.AreEqual(expected, result);
  }
}
