using CGLabs;
using CGLabs.Interfaces;

namespace BmpWriter;

public class BmpWriter : IImageWriter
{
  public string Format => "bmp";

  public byte[] WriteImage(Pixel[,] pixels, int maxColorValue)
  {
    if (pixels == null || pixels.Length == 0)
      throw new ArgumentException("Invalid pixel data");

    double colorCoef = maxColorValue / 255.0;

    int width = pixels.GetLength(1);
    int height = pixels.GetLength(0);

    int bytesPerPixel = 3;
    int rowSize = width * bytesPerPixel;
    int paddingSize = (4 - (rowSize % 4)) % 4;
    int pixelDataSize = (rowSize + paddingSize) * height;
    int fileSize = 54 + pixelDataSize;

    byte[] fileContent = new byte[fileSize];

    fileContent[0] = (byte)'B';
    fileContent[1] = (byte)'M';
    Array.Copy(BitConverter.GetBytes(fileSize), 0, fileContent, 2, 4);
    Array.Copy(BitConverter.GetBytes(0), 0, fileContent, 6, 2);
    Array.Copy(BitConverter.GetBytes(54), 0, fileContent, 10, 4);
    Array.Copy(BitConverter.GetBytes(40), 0, fileContent, 14, 4);
    Array.Copy(BitConverter.GetBytes(width), 0, fileContent, 18, 4);
    Array.Copy(BitConverter.GetBytes(height), 0, fileContent, 22, 4);
    Array.Copy(BitConverter.GetBytes((ushort)1), 0, fileContent, 26, 2);
    Array.Copy(BitConverter.GetBytes((ushort)(bytesPerPixel * 8)), 0, fileContent, 28, 2);
    Array.Copy(BitConverter.GetBytes(0), 0, fileContent, 30, 4);
    Array.Copy(BitConverter.GetBytes(pixelDataSize), 0, fileContent, 34, 4);
    Array.Copy(BitConverter.GetBytes(2835), 0, fileContent, 38, 4);
    Array.Copy(BitConverter.GetBytes(2835), 0, fileContent, 42, 4);
    Array.Copy(BitConverter.GetBytes(0), 0, fileContent, 46, 4);
    Array.Copy(BitConverter.GetBytes(0), 0, fileContent, 50, 4);

    int pixelIndex = 54;
    for (int y = height - 1; y >= 0; y--)
    {
      for (int x = 0; x < width; x++)
      {
        Pixel pixel = pixels[y, x];
        fileContent[pixelIndex++] = (byte)Math.Round(pixel.B * colorCoef);
        fileContent[pixelIndex++] = (byte)Math.Round(pixel.G * colorCoef);
        fileContent[pixelIndex++] = (byte)Math.Round(pixel.R * colorCoef);
      }

      pixelIndex += paddingSize;
    }

    return fileContent;
  }
}
