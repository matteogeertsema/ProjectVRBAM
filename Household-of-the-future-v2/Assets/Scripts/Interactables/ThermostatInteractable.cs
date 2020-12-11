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
    public PostProcessVolume volume;

    private ColorGrading _ColorGrading;

    // Start is called before the first frame update
    public override void OnStart() {
        audioPlayer = GameObject.FindObjectOfType<AudioPlayer>();
        if(!audioPlayer){
            Debug.LogError("No instance of Audioplayer found");
        }
        volume.profile.TryGetSettings(out _ColorGrading);
        _ColorGrading.temperature.value = 0;
    }

    public override void OnSelect() {
        //throw new System.NotImplementedException();
    }

    public override void OnDeselect() {
        //throw new System.NotImplementedException();
    }

    public override void OnActivate() {
        if (audioPlayer) {
            audioPlayer.play("Switch");
        }

        CVon();
    }


    public void CVon()
    {
        StartCoroutine(Lerp());

    }

    IEnumerator Lerp()

    {
        float startValue = 0;
        float endValue = 75;
        float timeElapsed = 0;

        while (timeElapsed < cvDuration)
        {
            _ColorGrading.temperature.value = Mathf.Lerp(startValue, endValue, timeElapsed / cvDuration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }

        _ColorGrading.temperature.value = endValue;
    }


    //blic void CVoff()
    //
    //  _ColorGrading.temperature.value = Mathf.Lerp(_ColorGrading.temperature.value, 0, .5f * Time.deltaTime);
    //
    public override void OnUpdate()
    {

    }

    public override bool isActive() {
        return false;
    }
}