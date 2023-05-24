using CGLabs.Factories;

var cmdArgs = CommandLineParser.ParseOptions(args);

var pluginFactory = new PluginFactory("PluginsDLLs");

string maxColorValue = cmdArgs.GetValueOrDefault("maxColor", "255");

var inputFileName = cmdArgs.GetValueOrDefault("source", "");
if (inputFileName == "")
  throw new Exception("not found --source argument");
var inputFormat = inputFileName.Split('.')[1];
var outputFileName = cmdArgs.GetValueOrDefault("target", "");
if (outputFileName == "")
  throw new Exception("not found --target argument");
var outputFormat = outputFileName.Split('.')[1];

var reader = pluginFactory.GetImageReader(inputFormat);
var writer = pluginFactory.GetImageWriter(outputFormat);

var pixels = reader.ReadImage(File.ReadAllBytes(inputFileName));

File.WriteAllBytes(outputFileName, writer.WriteImage(pixels, int.Parse(maxColorValue)));
