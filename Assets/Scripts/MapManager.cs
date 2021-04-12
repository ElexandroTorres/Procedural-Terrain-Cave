using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    [Range(0.001f, 50.0f)]
    public float scale;
    public int octaves;
    public float persistence;

    private NoiseTexture noiseTexture;

    public void ShowTextureInfos()
    {
        noiseTexture = GetComponent<NoiseTexture>();
        noiseTexture.ShowTextureNoise(width, height, scale);
    }

}
