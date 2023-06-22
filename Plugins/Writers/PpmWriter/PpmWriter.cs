using CGLabs.Interfaces;
using CGLabs;
using System.Text;

namespace PpmWriterNS;

public class PpmWriter : IImageWriter
{
  public string Format => "ppm";

  public byte[] ImageToBytes(Pixel[,] pixels, int maxColorValue)
  {
    double colorCoef = maxColorValue / 255.0;
    StringBuilder sb = new StringBuilder();
    sb.Append($"P3\n{pixels.GetLength(1)} {pixels.GetLength(0)}\n{maxColorValue}\n");

    for (int i = 0; i < pixels.GetLength(0); i++)
    {
      for (int j = 0; j < pixels.GetLength(1); j++)
      {
        Pixel chunk = pixels[i, j];
        sb.Append(
          $"{Math.Round(chunk.R * colorCoef)} {Math.Round(chunk.G * colorCoef)} {Math.Round(chunk.B * colorCoef)}\t"
        );
      }

      sb.Append('\n');
    }
    return Encoding.ASCII.GetBytes(sb.ToString());
  }
}
