using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureDisplay : MonoBehaviour
{
    public ThermostatInteractable thermostatInteractable;
    public UnityEngine.UI.Text temperatureText;
    public TemperatureController temperatureController;

    // Start is called before the first frame update
    void Start()
    {
        string s = tempToCelsius(temperatureController.getMinTemp()).ToString();
        setTemperatureText(s);
    }

    // Update is called once per frame
    void Update()
    {
        changeDisplay();
    }

    public void changeDisplay()
    {
        if (thermostatInteractable.isActive() == true)
        {

            string s = tempToCelsius(temperatureController.getTemperature()).ToString();
            setTemperatureText(s);
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
