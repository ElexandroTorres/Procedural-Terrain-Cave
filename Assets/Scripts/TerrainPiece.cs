using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class TerrainPiece : MonoBehaviour
{
    [SerializeField] private List<GameObject> _Colectables;
    [SerializeField] private GameObject _tree;
    [SerializeField] private GameObject _rock;
    [SerializeField] private GameObject _caveEntrace;

    [SerializeField] private MeshGenerator terrainMeshPrefab;

    float[,] _treeMap;

    public MapConfigs mapConfigs;
    /*
    void Start()
    {
        _treeMap = NoiseGenerator.GenerateNoise(mapConfigs.width + 1, mapConfigs.height + 1, _xPosition, _zPosition,
            mapConfigs.scale, mapConfigs.octaves, mapConfigs.persistance);

        int currentX = mapConfigs.startX - (mapConfigs.width / 2) - mapConfigs.width;
        int currentZ = mapConfigs.startZ - (mapConfigs.height / 2) - mapConfigs.height;

        Instantiate(terrainMeshPrefab, new Vector3(currentX, 0, currentZ), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */
}
