using CGLabs;
using CGLabs.Factories;
using CGLabs.Objects;

var cmdArgs = CommandLineParser.ParseOptions(args);

var pluginFactory = new PluginFactory("PluginsDLLs");

string maxColorValue = cmdArgs.GetValueOrDefault("maxColor", "255");

var inputFileName = cmdArgs.GetValueOrDefault("source", "");
if (inputFileName == "")
  throw new Exception("not found --source argument");

var outputFileName = cmdArgs.GetValueOrDefault("target", ".console");
var outputFormat = outputFileName.Split('.')[1];

var inputBytes = File.ReadAllBytes(inputFileName);
var mesh = WfObjReader.ReadObjFile(inputBytes);

var transformMatrix = Matrixes.MatrixMultiplication(
  Matrixes.RotateAroundX((float)Math.PI / 2),
  Matrixes.Scale(1.5f, 1.5f, 1.5f),
  Matrixes.Translate(0.05f, 0, 1)
);

foreach (var face in mesh)
  face.Transform(transformMatrix);

int width = outputFileName == ".console" ? 140 : 480;
int height = outputFileName == ".console" ? 50 : 360;
float fovDeg = 60;
var fovRad = (float)(fovDeg / 180 * Math.PI);
var camera = new Camera(new Point(0, 0, -1), new Vector(0, 0, 1), fovRad, width, height);
var light = new LightSource(1, -2, 1).Normalize();
var scene = new Scene(camera, light);

scene.AddFigures(mesh);

var writer = pluginFactory.GetImageWriter(outputFormat);
var bytes = scene.Render(writer, int.Parse(maxColorValue));

if (outputFileName == ".console")
  Console.OpenStandardOutput().Write(bytes);
else
  File.WriteAllBytes(outputFileName, bytes);
