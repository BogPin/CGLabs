namespace CGLabs.Interfaces;

public interface IImageWriter
{
  public string Format { get; }
  public byte[] ImageToBytes(Pixel[,] image, int maxColorValue);
}
