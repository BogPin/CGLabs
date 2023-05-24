using System.Reflection;
using CGLabs.Interfaces;

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
      var dllFile = new FileInfo(file);
      var types = Assembly.LoadFile(dllFile.FullName).GetTypes();
      _readers.AddRange(
        types.Where(t => typeof(IImageReader).IsAssignableFrom(t) && !t.IsInterface)
      );
      _writers.AddRange(
        types.Where(t => typeof(IImageWriter).IsAssignableFrom(t) && !t.IsInterface)
      );
    }
  }

  public IImageReader GetImageReader(string format)
  {
    foreach (var reader in _readers)
    {
      var instance = (IImageReader)Activator.CreateInstance(reader)!;
      if (format == instance.Format)
        return instance;
    }
    throw new Exception($"Not found reader for format {format}");
  }

  public IImageWriter GetImageWriter(string format)
  {
    foreach (var writer in _writers)
    {
      var instance = (IImageWriter)Activator.CreateInstance(writer)!;
      if (format == instance.Format)
        return instance;
    }
    throw new Exception($"Not found reader for format {format}");
  }
}
