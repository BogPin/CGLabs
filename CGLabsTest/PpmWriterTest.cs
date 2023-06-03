using System.Text;
using CGLabs;
using PpmWriterNS;

namespace CGLabsTest;

public class TestWriter
{
  [Test]
  public void PixelsToPpm_ReturnsCorrectPpmByteArray()
  {
    // Arrange
    Pixel[,] pixels = new Pixel[,]
    {
      { new Pixel(255, 0, 0), new Pixel(0, 255, 0) },
      { new Pixel(0, 0, 255), new Pixel(255, 255, 255) }
    };
    int maxColorValue = 255;
    PpmWriter ppmWriter = new PpmWriter();

    // Act
    byte[] result = ppmWriter.WriteImage(pixels, maxColorValue);

    // Assert
    byte[] expected = Encoding.ASCII.GetBytes(
      "P3\n2 2\n255\n255 0 0\t0 255 0\t\n0 0 255\t255 255 255\t\n"
    );
    Assert.AreEqual(expected, result);
  }

  [Test]
  public void Format_ReturnsPpm()
  {
    // Arrange
    PpmWriter ppmWriter = new PpmWriter();

    // Act
    string format = ppmWriter.Format;

    // Assert
    Assert.AreEqual("ppm", format);
  }
}
