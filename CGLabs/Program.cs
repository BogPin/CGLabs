using CGLabs.Factories;
using CGLabs.Objects;

var cmdArgs = CommandLineParser.ParseOptions(args);

var pluginFactory = new PluginFactory("PluginsDLLs");

string maxColorValue = cmdArgs.GetValueOrDefault("maxColor", "255");

var inputFileName = cmdArgs.GetValueOrDefault("source", "");
if (inputFileName == "")
  throw new Exception("not found --source argument");

var outputFileName = cmdArgs.GetValueOrDefault("target", "");
if (outputFileName == "")
  throw new Exception("not found --target argument");
var outputFormat = outputFileName.Split('.')[1];

var inputStream = File.OpenRead(inputFileName);

// TODO: implement MeshReader with method "ITraceable[] Read(Stream stream)"
// var meshReader = new MeshReader();
// var mesh = meshReader.Read(inputStream);

int width = 135,
  height = 35;
float fovDeg = 60;
var fovRad = (float)(fovDeg / 180 * Math.PI);
var camera = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fovRad, width, height);
var light = new LightSource(1, -2, 1);
var scene = new Scene(camera, light);

// scene.AddFigures(mesh);
// var pixels = scene.Render();

var writer = pluginFactory.GetImageWriter(outputFormat);

// File.WriteAllBytes(outputFileName, writer.WriteImage(pixels, int.Parse(maxColorValue)));
