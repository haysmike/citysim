using System.Collections.Generic;
using UnityEngine;

using com.heparo.terrain.toolkit;

public class TerrainController : MonoBehaviour {
    private TerrainToolkit toolkit;
    private Terrain terrain;

    void Start() {
        terrain = GetComponent<Terrain>();
        if (terrain == null) return;

        toolkit = GetComponent<TerrainToolkit>();
        if (toolkit == null) return;

        // Thread thread = new Thread(GenerateTerrain);
        // thread.Start();
        GenerateTerrain();
    }

    void GenerateTerrain() {
        terrain.enabled = false;
        // if (toolkit.heightBlendPoints == null) {
        //     Debug.Log("Setting height blend points");
        //     toolkit.heightBlendPoints = new List<float>();
        // }
        toolkit.setPerlinPreset(new TerrainToolkit.perlinPresetData("", 8, 0.5f, 4, 1.0f));
        toolkit.generateTerrain(onProgressUpdate);
        toolkit.textureTerrain(onProgressUpdate);
        toolkit.setFullHydraulicErosionPreset(new TerrainToolkit.fullHydraulicErosionPresetData("", 25, 0.01f, 0.5f, 0.06f, 0.6f));
        toolkit.erodeAllTerrain(onErosionProgressUpdate);
        // toolkit.erodeAllTerrain(onErosionProgressUpdate);
        terrain.enabled = true;
    }

    void onProgressUpdate(string titleString, string displayString, float percentComplete) {
        Debug.Log(titleString + " - " + displayString + " " + percentComplete +"%");
    }

    public void onErosionProgressUpdate(string titleString, string displayString, int iteration, int nIterations, float percentComplete ){
        onProgressUpdate(titleString, displayString+" Iteration "+iteration+" of "+nIterations+". Please wait.", percentComplete);
    }
}
