namespace CGLabs.Objects
{
    public class Vector
    {
        public float X, Y, Z;

        public Vector(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Vector Add(Vector vector)
        {
            return new Vector(this.X + vector.X, this.Y + vector.Y, this.Z + vector.Z);
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y}, {this.Z})";
        }
        
    }
}