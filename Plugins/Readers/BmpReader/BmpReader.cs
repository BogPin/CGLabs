using CGLabs;
using CGLabs.Interfaces;

namespace BmpReaderNS;

public class BmpReader : IImageReader
{
  public string Format => "bmp";

  public Pixel[,] ReadImage(byte[] fileContent)
  {
    if (fileContent == null || fileContent.Length < 54)
            throw new ArgumentException("Invalid file content");

        // Extract BMP header information
        int pixelDataOffset = BitConverter.ToInt32(fileContent, 10);
        int width = BitConverter.ToInt32(fileContent, 18);
        int height = BitConverter.ToInt32(fileContent, 22);
        int bitsPerPixel = BitConverter.ToInt16(fileContent, 28);

        // Validate header information
        if (pixelDataOffset < 54 || width <= 0 || height <= 0 || bitsPerPixel != 24)
            throw new ArgumentException("Invalid BMP file format");

        int rowSize = ((width * bitsPerPixel + 31) / 32) * 4; // Row size in bytes
        int pixelArraySize = rowSize * height;

        if (fileContent.Length - pixelDataOffset < pixelArraySize)
            throw new ArgumentException("Invalid BMP file format");

        Pixel[,] pixels = new Pixel[height, width];

        int pixelIndex = pixelDataOffset;
        for (int y = height - 1; y >= 0; y--)
        {
            for (int x = 0; x < width; x++)
            {
                int b = fileContent[pixelIndex++];
                int g = fileContent[pixelIndex++];
                int r = fileContent[pixelIndex++];
                pixels[y, x] = new Pixel((byte)r, (byte)g, (byte)b);
            }

            int paddingBytes = rowSize - (width * 3);
            pixelIndex += paddingBytes;
        }

        return pixels;
  }
}
