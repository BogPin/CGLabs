using CGLabs.Factories;
using CGLabs.Objects;

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

var inputBytes = File.ReadAllBytes(inputFileName);

var reader = pluginFactory.GetImageReader(inputBytes);
var writer = pluginFactory.GetImageWriter(outputFormat);

var pixels = reader.ReadImage(inputBytes);

File.WriteAllBytes(outputFileName, writer.WriteImage(pixels, int.Parse(maxColorValue)));

int width = 135,
  height = 35;
float fovDeg = 60;
var fovRad = (float)(fovDeg / 180 * Math.PI);
var camera = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fovRad, width, height);
var light = new LightSource(1, -2, 1);
var scene = new Scene(camera, light);
scene.AddFigure(new Disc(1, new Point(4, 0, 10), new Normal(1, 0, 0)));
scene.AddFigure(new Plane(new Normal(1, 1, 0), new Point(-1, 0, 0)));
scene.AddFigure(new Sphere(1, new Point(2, 0, 10)));
scene.AddFigure(new Sphere(0.5F, new Point(1, 0, 9)));
scene.Render();
