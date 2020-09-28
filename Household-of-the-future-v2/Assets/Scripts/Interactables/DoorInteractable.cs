using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a doorinteractable class. This class opens and closes doors with animation and sound
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class DoorInteractable : Interactable {

    public bool isOpen = false;
    private AudioPlayer audioPlayer;
    private Animator animator;

    public override void OnStart() {
        animator = this.gameObject.GetComponent<Animator>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public override bool isActive() {
        return isOpen;
    }

    public override void OnActivate() {
        if (isCurrentlyNotInAnimation()) {
            if (isOpen) {
                closeDoor();
            } else {
                openDoor();
            }
        }
    }

    private bool isCurrentlyNotInAnimation(){
        return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0);
    }

    private void closeDoor() {
        animator.Play("CloseDoor");
        audioPlayer.play("CloseDoor");
        isOpen = !isOpen;
    }

    private void openDoor() {
        animator.Play("OpenDoor");
        audioPlayer.play("OpenDoor");
        isOpen = !isOpen;
    }

    public override void OnDeselect() {
        //throw new System.NotImplementedException();
    }

    public override void OnSelect() {
        //throw new System.NotImplementedException();
    }

    public override void OnUpdate() {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
}