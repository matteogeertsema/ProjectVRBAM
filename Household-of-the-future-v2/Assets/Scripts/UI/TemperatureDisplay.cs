using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureDisplay : MonoBehaviour
{
    public ThermostatInteractable thermostatInteractable;
    public UnityEngine.UI.Text temperatureText;
    public UnityEngine.UI.Image temperatureImage;
    public TemperatureController temperatureController;

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

    public void changeTemperature()
    {
        if (thermostatInteractable.isActive() == true)
        {
            string s = tempToCelsius(temperatureController.getTemperature()).ToString();
            setTemperatureText(s);
        }
    }

    public void changeEmoji()
    {
        if(tempToCelsius(temperatureController.getTemperature()) <= 17)
        {
            temperatureImage.sprite = sprites[0];
        } 
        else if(tempToCelsius(temperatureController.getTemperature()) > 17 && tempToCelsius(temperatureController.getTemperature()) <= 19)
        {
            temperatureImage.sprite = sprites[2];
        }
        else
        {
            temperatureImage.sprite = sprites[1];
        }
    }

    public void setTemperatureText(string newTemperature)
    {
        this.temperatureText.text = newTemperature;
    }

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
