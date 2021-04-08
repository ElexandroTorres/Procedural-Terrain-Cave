using UnityEngine;

public static class PerlinNoise : MonoBehaviour
{
    public float[,] noiseMap;
    public int width = 50;
    public int height = 50;
    public float scale = 0.5f;

    public static PerlinNoise(int width, int height, float scale)
    {
        this.width = width;
        this.height = height;
        this.scale = scale;
    }

    public static float[,] GenerateNoiseMap(int width, int height, float scale)
    {
        this.width = width;
        this.height = height;
        this.scale = scale;

        this.noiseMap = new float[height, width];

        if(scale == 0)
        {
            scale = 0.00001f;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                noiseMap[y, x] = GenerateNoise(x, y);
            }
        }

        //Renderer renderer = GetComponent<Renderer>();  
        //renderer.sharedMaterial.mainTexture = GenerateTexture();
    }

    private void GenerateNoise(int x, int y)
    {
        float xCoord = (float)x / scale;
        float yCoord = (float)y / scale;
        return Mathf.PerlinNoise(xCoord, yCoord);
    }
   

}