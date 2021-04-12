using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class NoiseTexture : MonoBehaviour
{
    public MapConfigs mapConfigs;
    private float[,] noiseMap;
    public  int width;
    public int height;
    public float scale;

    public int octaves;
    public float persistance;

    public float lacunarity;

    void Start()
    {
        this.width = mapConfigs.width;
        this.height = mapConfigs.height;
        this.scale = mapConfigs.scale;
        this.octaves = mapConfigs.octaves;
        this.persistance = mapConfigs.persistance;
        this.lacunarity = mapConfigs.lacunarity;

        noiseMap = PerlinNoise.GenerateNoiseMap(width, height, scale, octaves, persistance, lacunarity);

        Renderer renderer = GetComponent<Renderer>();  
        renderer.sharedMaterial.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        //Color[] colorMap = new Color[height * width];

        for(int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                texture.SetPixel(x, y, CalculateColor(x, y));
                //colorMap[y * width + x] = Color.Lerp(Color.black, Color.white, noiseMap[y, x]);
            }
        }

        //texture.SetPixels(colorMap);
        texture.Apply();

    /*
        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();

        return texture;*/
        return texture;
    }
    
    Color CalculateColor(int x, int y)
    {
        //float sample = PerlinNoise.GenerateNoise(x, y, scale, octaves, persistance);
        float sample = noiseMap[y, x];

        return Color.Lerp(Color.black, Color.white, sample);
    }
    

}
