namespace CGLabs.Interfaces;

public interface IImageReader
{
  public string Format { get; }
  public Pixel[,] ReadImage(byte[] fileContent);
  public Boolean isValidFile(byte[] fileContent);
}
