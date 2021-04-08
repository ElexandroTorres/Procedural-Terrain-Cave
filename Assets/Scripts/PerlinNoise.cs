using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PerlinNoise : MonoBehaviour
{
    public int width = 50;
    public int height = 50;
    public float scale = 0.5f;

    public void GenerateNoiseMap()
    {
        if(scale == 0)
        {
            scale = 0.00001f;
        }

        Renderer renderer = GetComponent<Renderer>();  
        renderer.sharedMaterial.mainTexture = GenerateTexture();
    }
   
    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();

        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / scale;
        float yCoord = (float)y / scale;
        float sample = Mathf.PerlinNoise(xCoord, yCoord);

        return new Color(sample, sample, sample);
    }

}