using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMap : MonoBehaviour
{
    float[,] noiseMap;
    public int width = 50;
    public int height = 50;
    public float scale = 0.3f;
    public int octaves = 2;

    public float persistance = 0.5f;

    void Start()
    {
        noiseMap = new float[height, width];
    }

    void FillNoiseMap()
    {
        noiseMap = PerlinNoise.GenerateNoiseMap(width, height, scale, octaves, persistance);
    }
}
