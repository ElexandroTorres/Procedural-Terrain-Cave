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

    void Start()
    {
        this.width = mapConfigs.width;
        this.height = mapConfigs.height;
        this.scale = mapConfigs.scale;
        this.octaves = mapConfigs.octaves;
        this.persistance = mapConfigs.persistance;

        Renderer renderer = GetComponent<Renderer>();  
        renderer.sharedMaterial.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();

        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float sample = PerlinNoise.GenerateNoise(x, y, scale, octaves, persistance);

        return new Color(sample, sample, sample);
    }

}
