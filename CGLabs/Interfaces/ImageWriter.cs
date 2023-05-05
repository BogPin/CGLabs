namespace CGLabs.Interfaces;

  public interface IImageWriter
{
  public string Format { get; }
  public byte[] WriteImage(Pixel[,] image);
}
