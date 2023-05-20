using CGLabs;
using CGLabs.Interfaces;

namespace BmpReader;

public class BmpReader : IImageReader
{
    public string Format => "Bmp";

    public Pixel[,] ReadImage(byte[] fileContent)
    {
        Pixel[,] pixels;

        byte[] header = new byte[54];
        Array.Copy(fileContent, 0, header, 0, 54);

        int width = BitConverter.ToInt32(header, 18);
        int height = BitConverter.ToInt32(header, 22);

        int rowSize = width * 3;
        int padding = (4 - (rowSize % 4)) % 4;
        int rowBytes = rowSize + padding;

        byte[] pixelData = new byte[rowBytes * height];
        Array.Copy(fileContent, 54, pixelData, 0, rowBytes * height);

        pixels = new Pixel[height, width];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int pixelOffset = (y * rowBytes) + (x * 3);
                byte blue = pixelData[pixelOffset];
                byte green = pixelData[pixelOffset + 1];
                byte red = pixelData[pixelOffset + 2];

                pixels[y, x] = new Pixel(red, green, blue);
            }
        }

        return pixels;
    }
}