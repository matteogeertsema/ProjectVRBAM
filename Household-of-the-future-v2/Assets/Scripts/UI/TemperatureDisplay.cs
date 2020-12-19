using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureDisplay : MonoBehaviour
{
    public ThermostatInteractable thermostatInteractable;
    public UnityEngine.UI.Text temperatureText;

    // Start is called before the first frame update
    void Start()
    {
        
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
            string s = thermostatInteractable.getTemperature().ToString();
            setTemperatureText(s);
        }
    }

    public void setTemperatureText(string newTemperature)
    {
        this.temperatureText.text = newTemperature;
    }
}
