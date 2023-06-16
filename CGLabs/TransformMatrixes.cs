using System.Linq;

class Matrixes
{
  static public float[,] RotateAroundX(float rad)
  {
    return new float[3, 3]
    {
      { 1, 0, 0 },
      { 0, (float)Math.Cos(rad), (float)-Math.Sin(rad) },
      { 0, (float)Math.Sin(rad), (float)Math.Cos(rad) },
    };
  }

  static public float[,] RotateAroundY(float rad)
  {
    return new float[3, 3]
    {
      { (float)Math.Cos(rad), 0, (float)Math.Sin(rad) },
      { 0, 1, 0 },
      { (float)-Math.Sin(rad), 0, (float)Math.Cos(rad) },
    };
  }

  static public float[,] RotateAroundZ(float rad)
  {
    return new float[3, 3]
    {
      { (float)Math.Cos(rad), (float)-Math.Sin(rad), 0 },
      { (float)Math.Sin(rad), (float)Math.Cos(rad), 0 },
      { 0, 0, 1 },
    };
  }

  static public float[,] MatrixMultiplication(params float[][,] matrices)
  {
    if (matrices.Length < 2)
      throw new Exception("minimum 2 matrices are expected");

    return matrices.Aggregate(
      (acc, cur) =>
      {
        if (acc.GetUpperBound(1) != cur.GetUpperBound(0))
          throw new Exception(
            "second dimension of first matrix must be equal to first dimension of second matrix"
          );
        var M = acc.GetUpperBound(0) + 1;
        var N = cur.GetUpperBound(1) + 1;
        var res = new float[M, N];
        for (var i = 0; i < M; i++)
        {
          for (var j = 0; j < N; j++)
          {
            res[i, j] = 0;
            for (var k = 0; k < cur.GetUpperBound(0) + 1; k++)
            {
              res[i, j] += acc[i, k] * cur[k, j];
            }
          }
        }
        return res;
      }
    );
  }
}
