using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Turns emission property of material on or off when the light component is on or off respectively.
*/

public class EmissionControl : MonoBehaviour {

    private Material material;
    private Light light;
    private bool isEmissionOn;

    private void Start() {
        light = GetComponentsInChildren<Light>() [0];
        material = GetComponent<Renderer>().material;
        if(isLightOn()){
            turnEmissionOn();
        } else {
            turnEmissionOff();
        }
    }

    void Update() {
        if (!isLightOn() && isEmissionOn) {
            turnEmissionOff();
        } else if (isLightOn() && !isEmissionOn) {
            turnEmissionOn();
        }
    }

    private bool isLightOn() {
        return light.enabled;
    }

    private void turnEmissionOff() {
        material.DisableKeyword("_EMISSION");
        isEmissionOn = false;
    }

    private void turnEmissionOn() {
        material.EnableKeyword("_EMISSION");
        isEmissionOn = true;
    }
}