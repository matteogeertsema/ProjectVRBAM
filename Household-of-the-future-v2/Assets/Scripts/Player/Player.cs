using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

    public float speed = 1f;
    public float lookSensitivity = 2f;
    public GameObject camera;
    public GameObject mobile;
    protected bool toggleDisplayPhoneVisible = false;

    public bool canControlPlayer = true;
    protected Interactable currentInteractableSelected;

    protected Game game;
    private Settings sceneSettings;

    public abstract void move();
    public abstract void look();
    public abstract void toggleDisplayPhone();
    public abstract void checkCurrentSelectedInteractable();
    public abstract void checkUserInteractionInput();
    public abstract void returnToMenu();

    private void Awake() {
        game = GameObject.FindObjectOfType<Game>();
        sceneSettings = GameObject.FindObjectOfType<Settings>();
    }

    protected virtual void Update() {
        if (canControlPlayer) {
            checkForUserInput();
        }
    }

    public void checkForUserInput() {
        move();
        look();
        if (sceneSettings.getIsSmartHome()) {
            toggleDisplayPhone();
        }
        checkCurrentSelectedInteractable();
        checkUserInteractionInput();
        returnToMenu();
    }

    public void disablePlayerControls() {
        this.canControlPlayer = false;
    }

    public void enablePlayerControls() {
        this.canControlPlayer = true;
    }

    public void interact() {
        currentInteractableSelected.Activate();
    }

    public void setSpeed(float speed) {
        if (speed > 0f && speed < 1f) {
            this.speed = speed;
        }
    }
}