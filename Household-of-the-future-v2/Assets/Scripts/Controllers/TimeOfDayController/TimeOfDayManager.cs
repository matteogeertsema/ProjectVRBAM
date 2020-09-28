using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeOfDayManager : MonoBehaviour {
    public enum DayPart { NIGHT, DAY }

    public Material skyboxNight;
    public Material skyboxDay;

    public Color colorOfBulbLights;
    public float rangeOfBulbLights = 10f;

    public Light mainLight;
    public Color mainLightDayColor;
    public float mainLightDayIntensity = 1f;
    public Color mainLightNightColor;
    public float mainLightNightIntensity = 1f;

    private LightmapSwitcher lightMapSwitcher;
    private bool nightTime;

    private void Awake() {
        lightMapSwitcher = FindObjectOfType<DayNightLightmapSwitcher>();
    }

    protected void Start() {
        setColorOfLights(colorOfBulbLights);
        setRangeOfLights(rangeOfBulbLights);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            Debug.Log("Switching lightmap to night");
            setNightTime();
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            Debug.Log("Switching lightmap to day");
            setDayTime();
        }
    }

    public void setDayPart(DayPart daypart) {
        switch (daypart) {
            case DayPart.NIGHT:
                setNightTime();
                break;
            case DayPart.DAY:
                setDayTime();
                break;
        }
    }

    protected virtual void setNightTime() {
        setSkyBox(skyboxNight);
        setMainLightColor(mainLightNightColor);
        setMainLightIntensity(mainLightNightIntensity);
        lightMapSwitcher.applyNightLightmap();
        this.nightTime = true;

    }

    protected virtual void setDayTime() {
        setSkyBox(skyboxDay);
        setMainLightColor(mainLightDayColor);
        setMainLightIntensity(mainLightDayIntensity);
        lightMapSwitcher.applyDayLightmap();
        this.nightTime = false;
    }

    public bool isNightTime() {
        return nightTime;
    }

    private void setSkyBox(Material skybox) {
        RenderSettings.skybox = skybox;
    }

    private void setMainLightColor(Color color) {
        this.mainLight.color = color;
    }

    private void setMainLightIntensity(float intensity) {
        mainLight.intensity = intensity;
    }

    protected void setIntensityOfLights(float intensity) {
        foreach (Light light in FindObjectsOfType<Light>()) {
            if (light != mainLight) {
                light.intensity = intensity;
            }
        }
    }

    private void setColorOfLights(Color color) {
        foreach (Light light in FindObjectsOfType<Light>()) {
            if (light != mainLight) {
                light.color = color;
            }
        }
    }

    private void setRangeOfLights(float range) {
        foreach (Light light in FindObjectsOfType<Light>()) {
            if (light != mainLight) {
                light.range = range;
            }
        }
    }
}