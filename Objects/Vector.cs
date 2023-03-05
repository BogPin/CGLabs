using System;

namespace CGLabs.Objects
{
    public class Vector
    {
        public float X, Y, Z;

        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector Add(Vector vector)
        {
            return new Vector(X + vector.X, Y + vector.Y, Z + vector.Z);
        }

        public float DotProduct(Vector vector)
        {
            return X * vector.X + Y * vector.Y + Z * vector.Z;
        }
        
        public Vector Sub(Vector vector)
        {
            return new Vector(X - vector.X, Y - vector.Y, Z - vector.Z);
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
    }
}