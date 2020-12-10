using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RefrigeratorInteractable : Interactable
{
    private AudioPlayer audioPlayer;

    public PostProcessVolume volume;

    private ColorGrading _ColorGrading;

    // Start is called before the first frame update
    public override void OnStart()
    {
        audioPlayer = GameObject.FindObjectOfType<AudioPlayer>();
        if (!audioPlayer)
        {
            Debug.LogError("No instance of Audioplayer found");
        }
    }

    public override void OnUpdate()
    {
        // Gets called on update
    }

    public override void OnSelect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeselect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnActivate()
    {


        if (audioPlayer)
        {
            audioPlayer.play("Switch");
        }

        volume.profile.TryGetSettings(out _ColorGrading);

        _ColorGrading.temperature.value = 75;
    }

    public override bool isActive()
    {
        return false;
    }
}

