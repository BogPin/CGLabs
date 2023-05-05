using System;
using CGLabs.Interfaces;
using CGLabs.Enums;

namespace CGLabs.Factories;

public class PluginFactory
{
  private List<System.Type> _readers = new();
  private List<System.Type> _writers = new();
  
  public PluginFactory(string dir)
  {
    var files = Directory.GetFiles(dir, "*.dll");
    foreach (var file in files)
    {
      var types = Assembly.LoadFile(file).GetTypes();
      _readers.Concat(
        types.Where(t => typeof(IImageReader).IsAssignableFrom(t) && !t.IsInterface).ToList()
      );
      _writers.Concat(
        types.Where(t => typeof(IImageWriter).IsAssignableFrom(t) && !t.IsInterface).ToList()
      );
    }
  }

  public IImageReader GetImageReader(ImageFormat format)
  {
    foreach (var reader in _readers)
    {
      var instance = (IImageReader)Activator.CreateInstance(reader);
      if (format.ToString() == instance.Format) return instance;
    }
    throw new Exception($"Not found reader for format {format}");
  }

  public IImageWriter GetImageWriter(ImageFormat format)
  {
    foreach (var writer in _writers)
    {
      var instance = (IImageWriter)Activator.CreateInstance(writer);
      if (format.ToString() == instance.Format) return instance;
    }
    throw new Exception($"Not found reader for format {format}");
  }
}
