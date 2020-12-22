﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TemperatureController : MonoBehaviour
{
    public PostProcessVolume volume;
    public float minTemp;
    public float maxTemp;

    private ColorGrading _ColorGrading;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out _ColorGrading);
        setTemperature(0);
    }

    public float getTemperature()
    {
        return _ColorGrading.temperature.value;
    }

    public void setTemperature(float temp)
    {
        _ColorGrading.temperature.value = temp;
    }

    public float getMinTemp()
    {
        return minTemp;
    }

    public float getMaxTemp()
    {
        return maxTemp;
    }
}