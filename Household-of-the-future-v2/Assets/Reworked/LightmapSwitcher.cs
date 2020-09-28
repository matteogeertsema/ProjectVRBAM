using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightmapSwitcher : MonoBehaviour {

    public abstract void applyNightLightmap();
    public abstract void applyDayLightmap();
    public abstract void applyBedroomLedLightmap();
    public abstract void applyStaircaseLedLightmap();

}