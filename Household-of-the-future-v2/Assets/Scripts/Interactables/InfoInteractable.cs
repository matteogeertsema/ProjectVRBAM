using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is for the info object. This class is making sure a sound is played when the info object is selected.
/// @Version: 1.0
/// @Authors: Florian Molenaars, Leon Smit
/// </summary>

public class InfoInteractable : Interactable {
    public string soundName;
    public float turnspeed = 3f;

    public override bool isActive() {
        return false;
    }

    public override void OnActivate() {
        FindObjectOfType<AudioPlayer>().play(soundName);
    }

    public override void OnDeselect() {

    }

    public override void OnSelect() { }

    public override void OnStart() {

    }

    public override void OnUpdate() {
        transform.Rotate(0.0f, turnspeed * Time.deltaTime, 0.0f);
    }
}