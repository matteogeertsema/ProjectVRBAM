using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfraredController : MonoBehaviour
{
    public string controllerName = "Placeholder";
    public float infraredDuration;
    private bool isWorking = false;
    public TemperatureController temperatureController;


    public void infraredOn()
    {
        isWorking = true;
        StartCoroutine(infraredOnActive());
    }

    IEnumerator infraredOnActive()

    {
        float timeElapsed = 0;

        while (timeElapsed < infraredDuration)
        {
            temperatureController.setTemperature(Mathf.Lerp(temperatureController.getMinTemp(), temperatureController.getMaxTemp(), timeElapsed / infraredDuration));
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        temperatureController.setTemperature(temperatureController.getMaxTemp());

    }

    public void infraredOff()
    {
        isWorking = false;
        StartCoroutine(infraredOffActive());
    }

    IEnumerator infraredOffActive()

    {
        float timeElapsed = 0;

        while (timeElapsed < infraredDuration)
        {
            temperatureController.setTemperature(Mathf.Lerp(temperatureController.getMaxTemp(), temperatureController.getMinTemp(), timeElapsed / infraredDuration));
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        temperatureController.setTemperature(temperatureController.getMinTemp());

    }

    public bool isOn()
    {
        return isWorking;
    }
}
