using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularHomeTimeOfDayManager : TimeOfDayManager {

    public float intensityOfBulbLights = 0.5f;

    private void Start() {
        base.Start();
        base.setIntensityOfLights(intensityOfBulbLights);
    }
}