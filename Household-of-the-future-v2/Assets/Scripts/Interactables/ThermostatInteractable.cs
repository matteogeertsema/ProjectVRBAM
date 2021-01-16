using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// This class is for the lightswitch object. The object takes lightcontroller as object so it knows which lights to turn off/on
/// 
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class ThermostatInteractable : Interactable {

    private AudioPlayer audioPlayer;
    public float cvDuration;
    private bool isBusy = false;
    private bool isWorking = false;

    public TemperatureController temperatureController;
    public ComfortController comfortController;

    // Start is called before the first frame update
    public override void OnStart() {
        audioPlayer = GameObject.FindObjectOfType<AudioPlayer>();
        if(!audioPlayer){
            Debug.LogError("No instance of Audioplayer found");
        }
    }

    public override void OnActivate() {
        if (audioPlayer) {
            audioPlayer.play("Switch");
        }

        if (!isWorking)
        {
            isBusy = true;
            isWorking = true;
            comfortController.insideTheWarmth(cvDuration);
            StartCoroutine(CVon());
        } else if (isWorking)
        {
            isBusy = true;
            isWorking = false;
            comfortController.outsideTheWarmth(cvDuration);
            StartCoroutine(CVoff());        }
        
    }

    IEnumerator CVon()

    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < cvDuration)
        {
            temperatureController.setTemperature(Mathf.Lerp(temporarilyTemp, temperatureController.getMaxTemp(), timeElapsed / cvDuration));
            timeElapsed += Time.deltaTime;

            if (isWorking == false)
            {
                yield break;
            }

            yield return null;
        }
        temperatureController.setTemperature(temperatureController.getMaxTemp());

        isBusy = false;
    }

    IEnumerator CVoff()

    {
        float timeElapsed = 0;
        float temporarilyTemp = temperatureController.getTemperature();

        while (timeElapsed < cvDuration)
        {
            temperatureController.setTemperature(Mathf.Lerp(temporarilyTemp, temperatureController.getMinTemp(), timeElapsed / cvDuration));
            timeElapsed += Time.deltaTime;

            if (isWorking == true)
            {
                yield break;
            }

            yield return null;
        }

        temperatureController.setTemperature(temperatureController.getMinTemp());
    
         isBusy = false;
    }

    public override bool isActive() {
        return isBusy;
    }

    public bool isOn()
    {
        return isWorking;
    }

    public override void OnUpdate()
    {

    }

    public override void OnSelect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeselect()
    {
        //throw new System.NotImplementedException();
    }

}