using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfraredController : MonoBehaviour
{
    public string controllerName = "Placeholder";
    public float infraredDuration;
    private bool isWorking = false;
    public TemperatureController temperatureController;
    public ComfortController comfortController;

    // Activates infaredpanel and looks if player is inside infraredpanel radius. If so change the comfort(gevoelstemperatuur in display)
    public void infraredOn()
    {
        isWorking = true;
        if(comfortController.isInWarmthRadius() == true)
        {
            comfortController.insideTheWarmth(infraredDuration);
        }
        StartCoroutine(infraredOnActive());
    }

    // Sets temperature of infraredpanel in a duration of time. Also checks if the infraredpanel is activated again and if so stops the loop
    IEnumerator infraredOnActive()
    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < infraredDuration)
        {
            temperatureController.setTemperature(Mathf.Lerp(temporarilyTemp, temperatureController.getMaxTemp(), timeElapsed / infraredDuration));
            timeElapsed += Time.deltaTime;

            if (isWorking == false)
            {
                yield break;
            }

            yield return null;
        }
        temperatureController.setTemperature(temperatureController.getMaxTemp());

    }

    // Deactivates infaredpanel and looks if player is inside infraredpanel radius. If so change the comfort(gevoelstemperatuur in display)
    public void infraredOff()
    {
        isWorking = false;
        if (comfortController.isInWarmthRadius() == true)
        {
            comfortController.outsideTheWarmth(infraredDuration);
        }
        StartCoroutine(infraredOffActive());
    }

    // Sets temperature of infraredpanel in a duration of time. Also checks if the infraredpanel is activated again and if so stops the loop
    IEnumerator infraredOffActive()

    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < infraredDuration)
        {
            temperatureController.setTemperature(Mathf.Lerp(temporarilyTemp, temperatureController.getMinTemp(), timeElapsed / infraredDuration));
            timeElapsed += Time.deltaTime;

            if (isWorking == true)
            {
                yield break;
            }

            yield return null;
        }
        temperatureController.setTemperature(temperatureController.getMinTemp());

    }
    // Gives back if infraredpanel is turned on or off
    public bool isOn()
    {
        return isWorking;
    }
    // Gets the duration that is set in unity
    // The duration is how long it takes to get from minTemp to maxTemp and vice versa
    public float getDuration()
    {
        return infraredDuration;
    }
}
