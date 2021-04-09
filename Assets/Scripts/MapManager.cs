using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    public float scale = 0.3f;
    public int octaves;
    public float persistence;

    private NoiseTexture noiseTexture;

    public void ShowTextureInfos()
    {
        noiseTexture = GetComponent<NoiseTexture>();
        noiseTexture.ShowTextureNoise(width, height, scale);
    }

}
