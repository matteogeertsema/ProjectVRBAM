using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComfortController : MonoBehaviour
{
    public TemperatureController temperatureController;
    public InfraredController infraredController;
    private float comfort;
    private float duration;
    private bool isWorking;
    private bool inWarmthRadius = false;

    // Start is called before the first frame update
    void Start()
    {
        comfort = temperatureController.getTemperature();
    }

    public void insideTheWarmth(float duration)
    {
        this.duration = duration;
        isWorking = true;
        StartCoroutine(insideTheWarmthCounter());
    }

    IEnumerator insideTheWarmthCounter()

    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < duration)
        {
            comfort = Mathf.Lerp(temporarilyTemp, temperatureController.getMaxTemp(), timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            if (isWorking == false)
            {
                yield break;
            }

            yield return null;
        }
        comfort = temperatureController.getMaxTemp();

    }

    public void outsideTheWarmth(float duration)
    {
        this.duration = duration;
        isWorking = false;
        StartCoroutine(outsideTheWarmthCounter());
    }

    IEnumerator outsideTheWarmthCounter()

    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < duration)
        {
            comfort = Mathf.Lerp(temporarilyTemp, temperatureController.getMinTemp(), timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            if (isWorking == true)
            {
                yield break;
            }

            yield return null;
        }
        comfort = temperatureController.getMinTemp();

    }

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
            comfort = Mathf.Lerp(temporarilyComfort, temperatureController.getMaxTemp(), timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            if (isWorking == false)
            {
                yield break;
            }

            yield return null;
        }
        comfort = temperatureController.getMaxTemp();

    }

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
            comfort = Mathf.Lerp(temporarilyComfort, temperatureController.getMinTemp(), timeElapsed / duration);
            timeElapsed += Time.deltaTime;

            if (isWorking == true)
            {
                yield break;
            }

            yield return null;
        }
        comfort = temperatureController.getMinTemp();

    }

    private void OnTriggerEnter(Collider other)
    {
        inWarmthRadius = true;
        if (infraredController.isOn() == true)
        {
            gettingWarm();
        }
    }

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
