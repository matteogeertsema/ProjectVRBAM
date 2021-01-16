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

    public void infraredOn()
    {
        isWorking = true;
        if(comfortController.isInWarmthRadius() == true)
        {
            comfortController.insideTheWarmth(infraredDuration);
        }
        StartCoroutine(infraredOnActive());
    }

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

    public void infraredOff()
    {
        isWorking = false;
        if (comfortController.isInWarmthRadius() == true)
        {
            comfortController.outsideTheWarmth(infraredDuration);
        }
        StartCoroutine(infraredOffActive());
    }

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

    public bool isOn()
    {
        return isWorking;
    }

    public float getDuration()
    {
        return infraredDuration;
    }
}
