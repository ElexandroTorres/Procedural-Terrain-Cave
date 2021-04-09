using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(MapManager))]
public class MapInfos : Editor
{
    public override void OnInspectorGUI()
    { 
        MapManager mapManager = (MapManager)target;

        DrawDefaultInspector();

        if(GUILayout.Button("Generate Texture Map"))
        {
            mapManager.ShowTextureInfos();
        }
    }
}
