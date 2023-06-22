class Matrixes
{
  static public float[,] Translate(float dX, float dY, float dZ)
  {
    return new float[4, 4]
    {
      { 1, 0, 0, 0 },
      { 0, 1, 0, 0 },
      { 0, 0, 1, 0 },
      { dX, dY, dZ, 1 },
    };
  }

  static public float[,] Scale(float timesX, float timesY, float timesZ)
  {
    return new float[4, 4]
    {
      { timesX, 0, 0, 0 },
      { 0, timesY, 0, 0 },
      { 0, 0, timesZ, 0 },
      { 0, 0, 0, 1 },
    };
  }

  static public float[,] RotateAroundX(float rad)
  {
    return new float[4, 4]
    {
      { 1, 0, 0, 0 },
      { 0, (float)Math.Cos(rad), (float)-Math.Sin(rad), 0 },
      { 0, (float)Math.Sin(rad), (float)Math.Cos(rad), 0 },
      { 0, 0, 0, 1 },
    };
  }

  static public float[,] RotateAroundY(float rad)
  {
    return new float[4, 4]
    {
      { (float)Math.Cos(rad), 0, (float)Math.Sin(rad), 0 },
      { 0, 1, 0, 0 },
      { (float)-Math.Sin(rad), 0, (float)Math.Cos(rad), 0 },
      { 0, 0, 0, 1 },
    };
  }

  static public float[,] RotateAroundZ(float rad)
  {
    return new float[4, 4]
    {
      { (float)Math.Cos(rad), (float)-Math.Sin(rad), 0, 0 },
      { (float)Math.Sin(rad), (float)Math.Cos(rad), 0, 0 },
      { 0, 0, 1, 0 },
      { 0, 0, 0, 1 },
    };
  }

  static public float[,] MatrixMultiplication(params float[][,] matrices)
  {
    if (matrices.Length < 2)
      throw new Exception("minimum 2 matrices are expected");

    return matrices.Aggregate(
      (acc, cur) =>
      {
        var prevM = acc.GetUpperBound(0) + 1;
        var prevN = acc.GetUpperBound(1) + 1;
        var curM = cur.GetUpperBound(0) + 1;
        var curN = cur.GetUpperBound(1) + 1;

        if (prevN != curM)
          throw new Exception(
            $"{prevM}x{prevN} matrix cannot be multiplied by {curM}x{curN} matrix"
          );

        var res = new float[prevM, curN];
        for (var i = 0; i < prevM; i++)
        {
          for (var j = 0; j < curN; j++)
          {
            res[i, j] = 0;
            for (var k = 0; k < curM; k++)
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
