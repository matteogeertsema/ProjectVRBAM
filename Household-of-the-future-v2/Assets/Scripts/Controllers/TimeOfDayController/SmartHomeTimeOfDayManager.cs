using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartHomeTimeOfDayManager : TimeOfDayManager {

    public float lightIntensityNight = 0.1f;
    public float lightIntensityMorning = 0.3f;
    public float lightIntensityAfternoon = 0.3f;
    public float lightIntensityEvening = 0.1f;

    protected override void setNightTime() {
        base.setNightTime();
        base.setIntensityOfLights(lightIntensityNight);
    }

    protected override void setDayTime() {
        base.setDayTime();
        base.setIntensityOfLights(lightIntensityMorning);
    }

}