using System;
using CGLabs.Objects;

public class TriangleIntersection
{
  public static bool RayIntersectsTriangle(
    Vector rayOrigin,
    Vector rayDirection,
    Vector vertex0,
    Vector vertex1,
    Vector vertex2,
    out Vector intersectionPoint
  )
  {
    intersectionPoint = new Vector(0f, 0f, 0f);

    Vector edge1 = vertex1 - vertex0;
    Vector edge2 = vertex2 - vertex0;

    Vector pVector = Vector.Cross(rayDirection, edge2);
    float determinant = Vector.Dot(edge1, pVector);

    if (Math.Abs(determinant) < float.Epsilon)
      return false;

    float inverseDeterminant = 1f / determinant;

    Vector tVector = rayOrigin - vertex0;
    float u = Vector.Dot(tVector, pVector) * inverseDeterminant;

    if (u < 0 || u > 1)
      return false;

    Vector qVector = Vector.Cross(tVector, edge1);
    float v = Vector.Dot(rayDirection, qVector) * inverseDeterminant;

    if (v < 0 || u + v > 1)
      return false;

    float t = Vector.Dot(edge2, qVector) * inverseDeterminant;

    if (t < 0)
      return false;

    intersectionPoint = rayOrigin + t * rayDirection;
    return true;
  }
}
