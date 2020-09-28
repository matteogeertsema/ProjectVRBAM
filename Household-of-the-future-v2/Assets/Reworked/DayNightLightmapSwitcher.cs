using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DayNightLightmapSwitcher : LightmapSwitcher {
    public Texture2D[] lightmapDayDir;
    public Texture2D[] lightmapDayColor;

    public Texture2D[] lightmapNightDir;
    public Texture2D[] lightmapNightColor;

    private LightmapData[] lightmapDay;
    private LightmapData[] lightmapNight;

    private void Awake() {
        if ((lightmapDayDir.Length != lightmapDayColor.Length) || (lightmapNightDir.Length != lightmapNightColor.Length)) {
            Debug.Log("In order for DayNightLightmapSwitcher to work, the LightMap lists must be of equal length");
            return;
        }

        createDayLightmaps();
        createNightLightmaps();
        applyDayLightmap();
    }

    private void createDayLightmaps() {
        lightmapDay = new LightmapData[lightmapDayDir.Length];
        for (int i = 0; i < lightmapDay.Length; i++) {
            lightmapDay[i] = new LightmapData();
            lightmapDay[i].lightmapDir = lightmapDayDir[i];
            lightmapDay[i].lightmapColor = lightmapDayColor[i];
        }
    }

    private void createNightLightmaps() {
        lightmapNight = new LightmapData[lightmapNightDir.Length];
        for (int i = 0; i < lightmapNight.Length; i++) {
            lightmapNight[i] = new LightmapData();
            lightmapNight[i].lightmapDir = lightmapNightDir[i];
            lightmapNight[i].lightmapColor = lightmapNightColor[i];
        }
    }

    public override void applyNightLightmap() {
        LightmapSettings.lightmaps = lightmapNight;
    }

    public override void applyDayLightmap() {
        LightmapSettings.lightmaps = lightmapDay;
    }

    public override void applyBedroomLedLightmap() {
        //throw new NotSupportedException();
    }

    public override void applyStaircaseLedLightmap() {
        //throw new NotSupportedException();
    }
}