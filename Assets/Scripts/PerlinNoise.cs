using UnityEngine;

public static class PerlinNoise
{
    static float maxNoiseHeight = float.MinValue;
    static float minNoiseHeight = float.MaxValue;
    public static float[,] GenerateNoiseMap(int width, int height, float scale, int octaves, float persistance, float lacunarity)
    {
        float[,] noiseMap = new float[height, width];    
 
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //float sampleX = x / scale;
                //float sampleY = y / scale;

                //float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                //noiseMap[y, x] = perlinValue;
                
                //noiseMap[y, x] = GenerateNoise(x, y, scale, octaves, persistance);
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for(int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency;
                    float sampleY = y / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    //total += Mathf.PerlinNoise(xCoord, yCoord) * amplitude;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                    
                }
                
                if(noiseHeight > maxNoiseHeight)
                {
                    maxNoiseHeight = noiseHeight;
                }
                else if(noiseHeight < minNoiseHeight)
                {
                    minNoiseHeight = noiseHeight;
                }

                noiseMap[y, x] = noiseHeight;
                
            }
        }
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //noiseMap[y, x] = Mathf.Clamp(noiseMap[y, x], 0, 1);
                noiseMap[y, x] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[y, x]);
            }
        }
        
        return noiseMap;

    }

    public static float[,] GenerateNoise(int width, int height, float scale, int octaves, float persistance)
    {
        float[,] noiseMap = new float[height, width];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
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

                noiseMap[y, x] = total / maxValue;

            }
        }

        //return total / maxValue;
        return noiseMap;
    }

    public static float[,] GenerateNoiseTeste(int width, int height, float scale)
    {
        float[,] noiseMap = new float[height, width];

        float frequency = 4.0f;
        
        for(int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float xCoord = (float)x / scale * frequency;
                float yCoord = (float)y / scale * frequency;

                //float perlinValue = Mathf.PerlinNoise(frequency * xCoord, frequency * yCoord);
                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);
                //perlinValue = Mathf.Clamp(perlinValue, 0, 1);

                noiseMap[y, x] = perlinValue;
            }
        }
        return noiseMap;
        
    }
   

}