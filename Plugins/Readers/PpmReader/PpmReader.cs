using CGLabs.Interfaces;
using CGLabs;
using System.Text;

namespace PpmReaderNS;

public class PpmReader : IImageReader
{
  public string Format => "ppm";
  private string PPM_MAGIC_NUMBER = "P3";

  public bool isValidFile(byte[] fileContent)
  {
    string content = Encoding.ASCII.GetString(fileContent);
    return content.StartsWith(PPM_MAGIC_NUMBER);
  }

  public Pixel[,] ReadImage(byte[] fileData)
  {
    var str = System.Text.Encoding.Default.GetString(fileData);

    string[] fileContent = str.Split('\n');
    string[] size = fileContent[1].Split(' ');
    int width = int.Parse(size[0]);
    int height = int.Parse(size[1]);
    int maxColor = int.Parse(fileContent[2]);
    Pixel[,] pixels = new Pixel[height, width];
    double colorCoef = 255.0 / maxColor;

    for (int i = 0, s = 3; i < height; i++, s++)
    {
      string[] pixelLine = fileContent[s].Split('\t');
      for (int j = 0; j < width; j++)
      {
        string[] colorArr = pixelLine[j].Split(' ');
        pixels[i, j] = new Pixel(
          (byte)(int.Parse(colorArr[0]) * colorCoef),
          (byte)(int.Parse(colorArr[1]) * colorCoef),
          (byte)(int.Parse(colorArr[2]) * colorCoef)
        );
      }
    }

    return pixels;
  }
}
