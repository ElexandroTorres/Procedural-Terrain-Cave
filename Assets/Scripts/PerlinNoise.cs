using UnityEngine;

public class PerlinNoise
{
    private static float[,] noiseMap;

    public static float[,] GenerateNoiseMap(int width, int height, float scale, int octaves, float persistance)
    {

        noiseMap = new float[height, width];
 
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                noiseMap[y, x] = GenerateNoise(x, y, scale, octaves, persistance);
            }
        }

        return noiseMap;

    }

    public static float GenerateNoise(int x, int y, float scale, int octaves, float persistance)
    {
        float total = 0;
        float frequency = 1;
        float amplitude = 1;
        float maxValue = 0;

        float xCoord = (float)x / scale * frequency;
        float yCoord = (float)y / scale * frequency;

        for(int i = 0; i < octaves; i++)
        {
            total += Mathf.PerlinNoise(xCoord, yCoord) * amplitude;

            maxValue += amplitude;

            amplitude *= persistance;
            frequency *= 2;
        }


        return total / maxValue;
        //return Mathf.PerlinNoise(xCoord, yCoord);
    }
   

}