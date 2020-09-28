using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LEDstripLightmapSwitcher : LightmapSwitcher {
    public Texture2D[] stairwayDir;
    public Texture2D[] stairwayColor;
    public Texture2D[] bedroomDir;
    public Texture2D[] bedroomColor;

    private LightmapData[] stairsLEDstrip;
    private LightmapData[] bedroomLEDStripLightmap;

    private void Start() {
        if ((stairwayDir.Length != stairwayColor.Length) || (bedroomDir.Length != bedroomColor.Length)) {
            Debug.Log("In order for LEDstripLightmapSwitcher to work, the LightMap lists must be of equal length");
            return;
        }

        createStairsLEDStripLightmap();
        createBedroomLEDStripLightmap();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Debug.Log("applyBedroomLedLightmap");
            applyBedroomLedLightmap();
        }

        if (Input.GetKeyDown(KeyCode.X)) {
            Debug.Log("applyStaircaseLedLightmap");
            applyStaircaseLedLightmap();
        }
    }

    private void createStairsLEDStripLightmap() {
        Debug.Log("createStairsLEDStripLightmap");
        stairsLEDstrip = new LightmapData[stairwayDir.Length];
        for (int i = 0; i < stairsLEDstrip.Length; i++) {
            stairsLEDstrip[i] = new LightmapData();
            stairsLEDstrip[i].lightmapDir = stairwayDir[i];
            stairsLEDstrip[i].lightmapColor = stairwayColor[i];
        }
    }

    private void createBedroomLEDStripLightmap() {
        Debug.Log("createBedroomLEDStripLightmap");
        bedroomLEDStripLightmap = new LightmapData[bedroomDir.Length];
        for (int i = 0; i < bedroomLEDStripLightmap.Length; i++) {
            bedroomLEDStripLightmap[i] = new LightmapData();
            bedroomLEDStripLightmap[i].lightmapDir = bedroomDir[i];
            bedroomLEDStripLightmap[i].lightmapColor = bedroomColor[i];
        }
    }

    public override void applyNightLightmap() {
        //throw new NotSupportedException();
    }

    public override void applyDayLightmap() {
        //throw new NotSupportedException();
    }

    public override void applyBedroomLedLightmap() {
        LightmapSettings.lightmaps = bedroomLEDStripLightmap;
    }

    public override void applyStaircaseLedLightmap() {
        LightmapSettings.lightmaps = stairsLEDstrip;
    }
}