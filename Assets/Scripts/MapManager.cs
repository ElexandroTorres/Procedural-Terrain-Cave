using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapConfigs mapConfigs;
    private NoiseTexture noiseTexture;

    private int width;
    private int height;
    private float scale;

    private int octaves;
    private float persistance;

    void Start()
    {
        width = mapConfigs.width;
        height = mapConfigs.height;
        scale = mapConfigs.scale;
        octaves = mapConfigs.octaves;
        persistance = mapConfigs.persistance;
    }

    /*
    public void ShowTextureInfos()
    {
        noiseTexture = GetComponent<NoiseTexture>();
        noiseTexture.ShowTextureNoise(width, height, scale, octaves, persistance);
    }
    */

}
