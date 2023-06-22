using CGLabs.Objects;
using FluentAssertions;

namespace CGLabsTest
{
  [TestFixture]
  public class SceneTest
  {
    [Test]
    public void ClosestObjectTest()
    {
      int width = 135,
        height = 35;
      float fovDeg = 60;
      var fovRad = (float)(fovDeg / 180 * Math.PI);
      var camera = new Camera(new Point(0, 0, 0), new Vector(0, 0, 1), fovRad, width, height);
      var light = new LightSource(0, -1, 0);
      var scene = new Scene(camera, light);
      var list = new List<Vertex>();
      list.Add(new Vertex(-1, -0.3f, 1, -1));
      list.Add(new Vertex(0.5f, -0.3f, 1, -1));
      list.Add(new Vertex(1, 1, 1, -1));
      scene.AddFigure(new TriangleFace(list));
      var list2 = new List<Vertex>();
      list2.Add(new Vertex(-1, 0, 2, -1));
      list2.Add(new Vertex(0, 0, 2, -1));
      list2.Add(new Vertex(0.5f, 1, 2, -1));
      scene.AddFigure(new TriangleFace(list2));

      var (point, normal) = scene.TracePixel(70, 25);

      point
        .Should()
        .BeEquivalentTo(new Point(0, 0, 1), options => options.ExcludingMissingMembers());
    }
  }
}
