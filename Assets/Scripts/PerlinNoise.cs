using UnityEngine;

// Três versos do noise foram implementadas para quesito de testes. Duas baseadas em videos e uma baseada
// um conteudo de noise. Depois apagar para ficar apenas com a usada no codigo.
public static class PerlinNoise
{
    /* Versão 1 do Noise */ 
    public static float[,] GenerateNoiseMap(int width, int height, int startX, int startY, float scale, int octaves, float persistance, float lacunarity)
    {
        float[,] noiseMap = new float[height, width];

        int testex = startX;
        int testey = startY;
 
        for (int y = 0; y < height; y++)
        {
            startX = testex;
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
                    Debug.Log(startX);
                    float sampleX = startX / scale * frequency;
                    float sampleY = startY / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    //total += Mathf.PerlinNoise(xCoord, yCoord) * amplitude;
                    noiseHeight += perlinValue * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                    
                }
                

                noiseMap[y, x] = noiseHeight;
                startX++;
            }
            startY++;
        }
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //noiseMap[y, x] = Mathf.Clamp(noiseMap[y, x], 0, 1);
                //noiseMap[y, x] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[y, x]);
            }
        }
        
        return noiseMap;

    }

    public static float[,] GenerateNoise(int width, int height, int startX, int startY, float scale, int octaves, float persistance)
    {
        float[,] noiseMap = new float[height, width];

        int testex = startX;
        int testey = startY;

        for (int y = 0; y < height; y++)
        {
            startX = testex;
            for (int x = 0; x < width; x++)
            {
                float total = 0;
                float frequency = 1;
                float amplitude = 1;
                float amplitudeSum = 0;

                for(int i = 0; i < octaves; i++)
                {
                    float xCoord = (float)startX / scale * frequency;
                    float yCoord = (float)startY / scale * frequency;


                    total += Mathf.PerlinNoise(xCoord, yCoord) * amplitude;

                    amplitudeSum += amplitude;

                    amplitude *= persistance;
                    frequency *= 2;
                }

                noiseMap[y, x] = total / amplitudeSum;
                startX++;
            }
            startY++;
        }

        //return total / maxValue;
        return noiseMap;
    }

    public static float[,] GenerateNoiseTeste(int width, int height, float scale, int startX, int startY)
    {
        float[,] noiseMap = new float[height, width];

        int testex = startX;
        int testey = startY;
        
        for(int y = 0; y < height; y++)
        {
            testex = startX;
            for (int x = 0; x < width; x++)
            {
                //float xCoord = (float)testex / width * frequency;
                //float yCoord = (float)testey / height * frequency;
                //fazer um for aqui.
                float xCoord = (float)testex / scale;
                float yCoord = (float)testey / scale;

                float frequency = 1.0f;

                float perlinValue = Mathf.PerlinNoise(frequency * xCoord + 15.3f, frequency * yCoord + 15.3f);

                frequency = 2.0f;

                perlinValue += 0.5f * Mathf.PerlinNoise(frequency * xCoord + 20.3f, frequency * yCoord + 14.7f);

                frequency = 4.0f;

                perlinValue += 0.25f * Mathf.PerlinNoise(frequency * xCoord + 60.1f, frequency * yCoord + 9.3f);

                frequency = 8.0f;

                perlinValue += 0.125f * Mathf.PerlinNoise(frequency * xCoord + 15.0f, frequency * yCoord + 12.8f);

                //float perlinValue = Mathf.PerlinNoise(frequency * xCoord, frequency * yCoord);
                //float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);
                //perlinValue = Mathf.Clamp(perlinValue, 0, 1);
                
                noiseMap[y, x] = perlinValue / (1.75f + 0.125f);
                testex++;
            }
            testey++;
        }
        return noiseMap;
        
    }
   

}