using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Let's the player sit on the toilet and disables movement if a step is active (To make player stuck on toilet)
/// @Version: 1.0
/// @Authors: Leon Smit, Daniël Geerts
/// </summary>
public class ToiletInteractable : Interactable {

    public Transform onTheToiletLocation;
    private Player player;
    private Transform locationBeforeSittingOnToilet;
    private AudioSource m_MyAudioSource;

    private bool isSittingOnTheToilet = false;

    public override void OnStart() {
        m_MyAudioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerController>().getPlayer();
    }

    public override bool isActive() {
        return isSittingOnTheToilet;
    }

    public override void OnActivate() {
        sitOnToilet();
    }

    private void sitOnToilet() {
        locationBeforeSittingOnToilet = player.GetComponent<Transform>();
        player.transform.SetPositionAndRotation(onTheToiletLocation.transform.position, onTheToiletLocation.transform.rotation);
        player.disablePlayerControls();

        this.GetComponent<BoxCollider>().isTrigger = true;
        isSittingOnTheToilet = true;
        StartCoroutine(waitAmoutOfSeconds(5));
    }

    IEnumerator waitAmoutOfSeconds(int amountInSeconds) {
        for (float i = 0; i <= amountInSeconds; i += Time.deltaTime) {
            yield return null;
        }
        getOffToilet();
    }

    private void getOffToilet() {
        m_MyAudioSource.Play();
        player.transform.SetPositionAndRotation(locationBeforeSittingOnToilet.transform.position, locationBeforeSittingOnToilet.transform.rotation);
        player.enablePlayerControls();
        isSittingOnTheToilet = false;
    }

    public override void OnDeselect() {

    }

    public override void OnSelect() {

    }

    private float smooth = 5.0f;
    private float tiltAngle = 60.0f;

    public override void OnUpdate() { }
}