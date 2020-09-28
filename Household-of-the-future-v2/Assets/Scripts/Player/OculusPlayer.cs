using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusPlayer : Player {

    private Vector2 axis;
    private OVRPlayerController OVRPlayerController;

    private void Start() {
        OVRPlayerController = GetComponent<OVRPlayerController>();
    }

    protected override void Update() {
        base.Update();
        OVRInput.Update();
        axis = OVRInput.Get(OVRInput.Axis2D.Any);
    }

    public override void move() {
        OVRPlayerController.UpdateMovement();
        // gameObject.transform.Translate(-Vector3.forward * speed * Mathf.Round(axis.y) * Time.deltaTime);
    }

    public override void look() {
        OVRPlayerController.RotateVRplayer(Mathf.Round(axis.x) * lookSensitivity * Time.deltaTime);
    }

    public override void toggleDisplayPhone() {
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad)) {
            mobile.SetActive(!toggleDisplayPhoneVisible);
            toggleDisplayPhoneVisible = !toggleDisplayPhoneVisible;
        }
    }

    public override void checkCurrentSelectedInteractable() {
        Debug.Log("Not yet implemented");
    }

    public override void checkUserInteractionInput() {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
            interact();
        }
    }

    public override void returnToMenu() {
        if (OVRInput.Get(OVRInput.Button.Back)) {
            game.getGameState().setState(State.RESET_GAME_INTERRUPT);
        }
    }
}