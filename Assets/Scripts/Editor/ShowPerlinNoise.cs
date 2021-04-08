using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(NoiseTexture))]
public class ShowPerlinNoise : Editor
{
    public override void OnInspectorGUI()
    { 
        NoiseTexture noiseTexture = (NoiseTexture)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate noise"))
        {
            noiseTexture.ShowTextureNoise();
        }
    }
}
