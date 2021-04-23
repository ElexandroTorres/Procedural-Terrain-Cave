using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public MapConfigs mapConfigs;

    public MeshGenerator terrainPrefab;

    public GameObject player;

    private TerrainPiece terrainPiece;

    //private List<MeshGenerator> terrains;

    private MeshGenerator[,] terrains;

    private Vector2[,] piecesPositions = new Vector2[3, 3];

    int seg = 0;

    void Start()
    {
        terrains = new MeshGenerator[3, 3];

        player.transform.position = new Vector3(mapConfigs.startX, 30, mapConfigs.startZ);

        // Para gerar 9. Caso mude, é necessarior olhar essa parte.
        int currentX = mapConfigs.startX - (mapConfigs.width / 2) - mapConfigs.width;
        int currentZ = mapConfigs.startZ - (mapConfigs.height / 2) - mapConfigs.height;

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                piecesPositions[i, j] = new Vector2(currentX, currentZ);
                terrains[i, j] = Instantiate(terrainPrefab, new Vector3(currentX, 0, currentZ), Quaternion.identity);
                currentX += mapConfigs.width;
            }
            currentZ += mapConfigs.height;
            currentX = mapConfigs.startX - (mapConfigs.width / 2) - mapConfigs.width;
        }
    }

    void Update()
    {
        //if(player.transform.position.x + mapConfigs.width)
        teste();
    }


    void teste()
    {
        
        float playerX = player.transform.position.x + mapConfigs.width;
        float playerZ = player.transform.position.z + mapConfigs.height;

        //Debug.Log("PosiçãoPlayer x: " + playerX.ToString());
        //Debug.Log("PosiçãoPlayr z: " + playerZ.ToString());

        int x = Mathf.RoundToInt(playerX / mapConfigs.width) * mapConfigs.width;
        int z = Mathf.RoundToInt(playerZ / mapConfigs.height) * mapConfigs.height;
        //int x = (int)(playerX - (mapConfigs.width / 2) - mapConfigs.width);
        //int z = (int)(playerZ - (mapConfigs.height / 2) - mapConfigs.height);


        for(int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if(piecesPositions[i, j].Equals(new Vector2(x, z)))
                {
                    //return;
                }
            }
        }

        if(seg < 5)
        {
            Debug.Log("Posição x: " + x.ToString());
            Debug.Log("Posição z: " + z.ToString());
            Instantiate(terrainPrefab, new Vector3(x, 0, z), Quaternion.identity);
            seg++;
        }
        
        

        
        
    }

    /*
    public void ShowTextureInfos()
    {
        noiseTexture = GetComponent<NoiseTexture>();
        noiseTexture.ShowTextureNoise(width, height, scale, octaves, persistance);
    }
    */

}
