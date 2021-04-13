using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MapConfig", menuName = "Map Config", order = 1)]
public class MapConfigs : ScriptableObject
{
    [Min(1)]
    public int width;
    [Min(1)]
    public int height;
    [Range(0.001f, 50.0f)]
    public float scale;
    [Min(1)]
    public int octaves;
    public float persistance;
    public float lacunarity;
    [System.Serializable]
    public class teste
    {
        public Color color;
    }

    public teste[] testes;
    void Start()
    {
        
    }

}
