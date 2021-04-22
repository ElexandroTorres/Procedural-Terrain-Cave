using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "MapConfig", menuName = "Map Config", order = 1)]
public class MapConfigs : ScriptableObject
{
    [Header("Configurações gerais do mapa: ")]
    [Min(1)] public int width;
    [Min(1)] public int height;
    public int numberTerrains = 9;
    public int startX;
    public int startZ;
    [Header("Configurações de ruido (noise): ")]
    [Range(0.001f, 50.0f)] public float scale;
    [Min(1)] public int octaves;
    public float persistance;
    public float lacunarity;
    [Header("Configurações de suavização: ")]
    [Min(1)] public float heightMutiplier;
    public AnimationCurve heightCurve;
    [Header("Configurações de biomas: ")]
    public Terrain[] terrains;
    [Header("Octaves do terreno personalizados: ")]
    public Octaves[] customsOctaves;
    [Header("Configurações de vegetação: ")]
    public float treeOcupation;

}
