using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class NoiseTexture : MonoBehaviour
{
    private float[,] noiseMap;
    private int width;
    private int height;
    private float scale;

    public void ShowTextureNoise(int width, int height, float scale)
    {
        this.width = width;
        this.height = height;
        this.scale = scale;

        noiseMap = PerlinNoise.GenerateNoiseMap(width, height, scale);

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
        float sample = noiseMap[y, x];

        return new Color(sample, sample, sample);
    }

}
