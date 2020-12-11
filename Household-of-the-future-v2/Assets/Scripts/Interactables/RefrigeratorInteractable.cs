using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RefrigeratorInteractable : Interactable
{
    private AudioPlayer audioPlayer;

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
    }

    public override bool isActive()
    {
        return false;
    }
}

