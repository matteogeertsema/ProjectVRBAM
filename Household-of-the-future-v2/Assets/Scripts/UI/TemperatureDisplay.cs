﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureDisplay : MonoBehaviour
{
    public ThermostatInteractable thermostatInteractable;
    public UnityEngine.UI.Text temperatureText;
    public UnityEngine.UI.Image temperatureImage;
    public TemperatureController temperatureController;
    public ComfortController comfortController;

    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        string s = tempToCelsius(temperatureController.getMinTemp()).ToString();
        setTemperatureText(s);
        sprites = Resources.LoadAll<Sprite>("Emoji");
    }

    // Update is called once per frame
    void Update()
    {
        changeTemperature();
        changeEmoji();
    }

    // Changes the temperature text in display to the accurate temperature value
    // Temperature only changes if cv is turning on or off (is busy)
    public void changeTemperature()
    {
        if (thermostatInteractable.isActive() == true)
        {
            string s = tempToCelsius(temperatureController.getTemperature()).ToString();
            setTemperatureText(s);
        }
    }

    // Changes emoji in display through the comfort value
    public void changeEmoji()
    {
        if(comfortController.getComfort() < 15)
        {
            temperatureImage.sprite = sprites[0];
        } 
        else if(comfortController.getComfort() >= 15 && comfortController.getComfort() < 45)
        {
            temperatureImage.sprite = sprites[2];
        }
        else
        {
            temperatureImage.sprite = sprites[1];
        }
    }

    // Set temperature display value
    public void setTemperatureText(string newTemperature)
    {
        this.temperatureText.text = newTemperature;
    }

    // Converts temperature value to celsius
    public int tempToCelsius(float temp)
    {
        Math.Round(temp);
        switch (temp)
        {
            case float t when (t >= 0 && t < 15):
                return 17;
            case float t when (t >= 15 && t < 30):
                return 18;
            case float t when (t >= 30 && t < 45):
                return 19;
            case float t when (t >= 45 && t < 60):
                return 20;
            case float t when (t >= 60 && t <= 75):
                return 21;
            default:
                return 17;
        }
    }
}
