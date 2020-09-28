using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
    public List<GameObject> lights;
    public bool attachBedroomLedStrip = false;
    public bool attachStairwayLedStrip = false;
    public bool ShowControllerInMobile = true;
    public string controllerName = "Placeholder";

    private LightmapSwitcher LEDlightmapSwitcher;
    private LightmapSwitcher dayNightLightmapSwitcher;
    private TimeOfDayManager timeOfDayManager;

    private void Awake() {
        LEDlightmapSwitcher = FindObjectOfType<LEDstripLightmapSwitcher>();
        timeOfDayManager = FindObjectOfType<TimeOfDayManager>();
        dayNightLightmapSwitcher = FindObjectOfType<DayNightLightmapSwitcher>();
    }

    private void Start() {
        if (!LEDlightmapSwitcher) {
            Debug.LogWarning("LEDlightmapSwitcher is missing.");
        }
        if (!dayNightLightmapSwitcher) {
            Debug.LogWarning("dayNightLightmapSwitcher is missing.");
        }
        if (!timeOfDayManager) {
            Debug.LogWarning("timeOfDayManager is missing.");
        }
    }

    public void TurnOn() {
        enableAssociatedLightsIf(timeOfDayManager.isNightTime());
        turnOnBedroomLedStripIf(timeOfDayManager.isNightTime() && attachBedroomLedStrip);
        turnOnStairwayLedStripIf(timeOfDayManager.isNightTime() && attachStairwayLedStrip);
    }

    public void TurnOff() {
        disableAssociatedLights();
        turnOffAssociatedLedstripsIf(timeOfDayManager.isNightTime() && (attachBedroomLedStrip || attachStairwayLedStrip));
    }

    public void Switch() {
        GameObject.FindObjectOfType<DomoticaController>().toggleLightsOf(this);
    }

    private void turnOffAssociatedLedstripsIf(bool shouldTurnOff) {
        if (shouldTurnOff) {
            dayNightLightmapSwitcher.applyNightLightmap();
        }
    }

    private void turnOnBedroomLedStripIf(bool shouldTurnOn) {
        if (shouldTurnOn) {
            LEDlightmapSwitcher.applyBedroomLedLightmap();
        }
    }

    private void turnOnStairwayLedStripIf(bool shouldTurnOn) {
        if (shouldTurnOn) {
            LEDlightmapSwitcher.applyStaircaseLedLightmap();
        }
    }

    private void enableAssociatedLightsIf(bool isNightTime) {
        if (isNightTime) {
            for (int i = 0; i < lights.Count; i++) {
                lights[i].GetComponentInChildren<Light>().enabled = true;
            }
        }
    }

    private void disableAssociatedLights() {
        for (int i = 0; i < lights.Count; i++) {
            lights[i].GetComponentInChildren<Light>().enabled = false;
        }
    }

    public void IncreaseLightIntesity() {
        for (int i = 0; i < lights.Count; i++) {
            lights[i].GetComponentInChildren<Light>().intensity = 8;
        }
    }

    public void DecreaseLightIntesity() {
        for (int i = 0; i < lights.Count; i++) {
            lights[i].GetComponentInChildren<Light>().intensity = 1.5f;
        }
    }
}