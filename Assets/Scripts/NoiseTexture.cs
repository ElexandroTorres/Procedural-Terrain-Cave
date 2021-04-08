using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class NoiseTexture : MonoBehaviour
{
    float[,] noiseMap;
    public int width = 50;
    public int height = 50;
    public float scale = 0.5f;
    public void ShowTextureNoise()
    {
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
