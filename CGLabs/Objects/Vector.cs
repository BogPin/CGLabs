using System;

namespace CGLabs.Objects
{
  public class Vector
  {
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Vector(float x, float y, float z)
    {
      X = x;
      Y = y;
      Z = z;
    }

    public static Vector operator -(Vector a) => new Vector(-a.X, -a.Y, -a.Z);

    public static Vector operator +(Vector a, Vector b)
    {
      return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector operator -(Vector a, Vector b)
    {
      return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector operator *(float a, Vector b)
    {
      return new Vector(a * b.X, a * b.Y, a * b.Z);
    }

    public static Vector Cross(Vector a, Vector b)
    {
      float x = a.Y * b.Z - a.Z * b.Y;
      float y = a.Z * b.X - a.X * b.Z;
      float z = a.X * b.Y - a.Y * b.X;
      return new Vector(x, y, z);
    }

    public static float Dot(Vector a, Vector b)
    {
      return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }

    public float DotProduct(Vector vector)
    {
      return X * vector.X + Y * vector.Y + Z * vector.Z;
    }

    public float GetLength()
    {
      return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
    }

    public Vector Normalize()
    {
      var length = GetLength();
      return new Vector(X / length, Y / length, Z / length);
    }

    public override string ToString()
    {
      return $"({X}, {Y}, {Z})";
    }

    public Point ToPoint()
    {
      return new Point(X, Y, Z);
    }
  }
}
