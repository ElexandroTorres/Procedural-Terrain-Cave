using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapConfigs mapConfigs;

    public MeshGenerator terrainPrefab;

    private TerrainPiece terrainPiece;

    private List<MeshGenerator> terrains;

    void Start()
    {
        terrains = new List<MeshGenerator>();

        // Para gerar 9. Caso mude, é necessarior olhar essa parte.
        int currentX = mapConfigs.startX - (mapConfigs.width / 2) - mapConfigs.width;
        int currentZ = mapConfigs.startZ - (mapConfigs.height / 2) - mapConfigs.height;

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Instantiate(terrainPrefab, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                currentX += mapConfigs.width;
            }
            currentZ += mapConfigs.height;
            currentX = mapConfigs.startX - (mapConfigs.width / 2) - mapConfigs.width;
        }
    }

    void SpawnObjects(int currentX, int currentZ)
    {
        
    }

    /*
    public void ShowTextureInfos()
    {
        noiseTexture = GetComponent<NoiseTexture>();
        noiseTexture.ShowTextureNoise(width, height, scale, octaves, persistance);
    }
    */

}
