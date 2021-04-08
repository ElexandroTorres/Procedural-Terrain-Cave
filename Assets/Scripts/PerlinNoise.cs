using UnityEngine;

public class PerlinNoise
{
    private static float[,] noiseMap;

    public static float[,] GenerateNoiseMap(int width, int height, float scale)
    {

        noiseMap = new float[height, width];
 
        if(scale == 0)
        {
            scale = 0.00001f;
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                noiseMap[y, x] = GenerateNoise(x, y, scale);
            }
        }

        return noiseMap;

    }

    private static float GenerateNoise(int x, int y, float scale)
    {
        float xCoord = (float)x / scale;
        float yCoord = (float)y / scale;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
   

}