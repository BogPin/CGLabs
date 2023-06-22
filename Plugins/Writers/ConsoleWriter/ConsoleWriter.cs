namespace ConsoleWriter;

using CGLabs;
using CGLabs.Interfaces;

class ConsoleWriter : IImageWriter
{
  public string Format => "console";

  public byte[] ImageToBytes(Pixel[,] pixels, int maxColorValue)
  {
    var m = pixels.GetLength(0);
    var n = pixels.GetLength(1);
    var buf = new byte[(m + 1) * n + 1];
    for (var i = 0; i < m; i++)
    {
      for (var j = 0; j < n; j++)
      {
        var pixel = pixels[i, j];
        var brightness = (pixel.R + pixel.G + pixel.B) / (255 * 3);
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
        buf[i * m + j] = (byte)ch;
      }
      buf[i * m + n] = (byte)'\n';
    }
    buf[(m + 1) * n] = (byte)'\n';
    return buf;
  }
}
