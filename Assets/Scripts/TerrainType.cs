using UnityEngine;
using System;

public enum TerrainType { WATER, SAND, DIRT, ROCK, SNOW };

[System.Serializable]
public class Octaves
{
    public float scale;
    public float persistance;
}

[System.Serializable]
public class Terrain
{
    public TerrainType terrainType;
    public float terrainHeight;
    public Color terrainColor;
}
