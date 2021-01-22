using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComfortController : MonoBehaviour
{
    public TemperatureController temperatureController;
    public InfraredController infraredController;
    // comfort = gevoelstemperatuur
    private float comfort;
    private float duration;
    private bool isWorking;
    private bool inWarmthRadius = false;

    // Start is called before the first frame update
    void Start()
    {
        comfort = temperatureController.getTemperature();
    }

    // Gets the duration so it works with cv and infrared. 
    public void insideTheWarmth(float duration)
    {
        this.duration = duration;
        isWorking = true;
        StartCoroutine(insideTheWarmthCounter());
    }

    // Sets comfort in a duration of time. Also checks if the warmth changes and if so stops the loop
    IEnumerator insideTheWarmthCounter()
    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < duration)
        {
            setComfort(Mathf.Lerp(temporarilyTemp, temperatureController.getMaxTemp(), timeElapsed / duration));
            timeElapsed += Time.deltaTime;

            if (isWorking == false)
            {
                yield break;
            }

            yield return null;
        }
        setComfort(temperatureController.getMaxTemp());

    }
    // Gets the duration so it works with cv and infrared.
    public void outsideTheWarmth(float duration)
    {
        this.duration = duration;
        isWorking = false;
        StartCoroutine(outsideTheWarmthCounter());
    }

    // Sets comfort in a duration of time. Also checks if the warmth changes and if so stops the loop
    IEnumerator outsideTheWarmthCounter()

    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < duration)
        {
            setComfort(Mathf.Lerp(temporarilyTemp, temperatureController.getMinTemp(), timeElapsed / duration));
            timeElapsed += Time.deltaTime;

            if (isWorking == true)
            {
                yield break;
            }

            yield return null;
        }
        setComfort(temperatureController.getMinTemp());

    }
    // Specifically made for if infaredpanel is on and player steps inside radius infrared, so it changes comfort without needing the current temperature
    // Gets called in OnTriggerEnter()
    public void gettingWarm()
    {
        this.duration = 10;
        isWorking = true; 
        StartCoroutine(gettingWarmCounter());
    }

    IEnumerator gettingWarmCounter()
    {
        float timeElapsed = 0;
        float temporarilyComfort = comfort;

        while (timeElapsed < duration)
        {
            setComfort(Mathf.Lerp(temporarilyComfort, temperatureController.getMaxTemp(), timeElapsed / duration));
            timeElapsed += Time.deltaTime;

            if (isWorking == false)
            {
                yield break;
            }

            yield return null;
        }
        setComfort(temperatureController.getMaxTemp());

    }

    // Specifically made for if infaredpanel is on and player steps outisde radius infrared, so it changes comfort without needing the current temperature
    // Gets called in OnTriggerExit()
    public void gettingCold()
    {
        this.duration = 10;
        isWorking = false;
        StartCoroutine(gettingColdCounter());
    }

    IEnumerator gettingColdCounter()

    {
        float timeElapsed = 0;
        float temporarilyComfort = comfort;

        while (timeElapsed < duration)
        {
            setComfort(Mathf.Lerp(temporarilyComfort, temperatureController.getMinTemp(), timeElapsed / duration));
            timeElapsed += Time.deltaTime;

            if (isWorking == true)
            {
                yield break;
            }

            yield return null;
        }
        setComfort(temperatureController.getMinTemp());

    }

    // Gets called if player enters the infraredpanel radius. Only changes comfort if the infraredpanel is on
    private void OnTriggerEnter(Collider other)
    {
        inWarmthRadius = true;
        if (infraredController.isOn() == true)
        {
            gettingWarm();
        }
    }

    // Gets called if player exits the infraredpanel radius. Only changes comfort if the infraredpanel is on
    private void OnTriggerExit(Collider other)
    {
        inWarmthRadius = false;
        if (infraredController.isOn() == true)
        {
           gettingCold();
        }
    }

    public float getComfort()
    {
        return comfort;
    }

    public void setComfort(float comfort)
    {
        this.comfort = comfort;
    }

    public bool isOn()
    {
        return isWorking;
    }

    public bool isInWarmthRadius()
    {
        return inWarmthRadius;
    }

}
