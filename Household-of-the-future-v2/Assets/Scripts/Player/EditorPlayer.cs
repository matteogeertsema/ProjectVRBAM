using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditorPlayer : Player {

    private Vector2 mouseLook;

    public float rayLength;
    public Image image;

    private RaycastHit vision;
    public Color crosshairDefaultColor = Color.white;
    public Color crosshairSelectColor = Color.green;

    public override void move() {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;
        transform.Translate(moveDirection);
    }

    public override void look() {
        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        Vector2 look = new Vector2(horizontal, vertical);
        mouseLook += look * lookSensitivity;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -80f, 80);

        camera.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        transform.localRotation = Quaternion.AngleAxis(mouseLook.x, transform.up);
    }

    public override void toggleDisplayPhone() {
        if (Input.GetKeyDown(KeyCode.T)) {
            mobile.SetActive(!toggleDisplayPhoneVisible);
            toggleDisplayPhoneVisible = !toggleDisplayPhoneVisible;
        }
    }

    public override void checkCurrentSelectedInteractable() {
        Vector3 origin = camera.transform.position;
        Vector3 direction = camera.transform.forward * rayLength;

        // Draw the Raycast and puts colliding object in vision variable
        Debug.DrawRay(origin, direction);
        if (Physics.Raycast(origin, direction, out vision, rayLength)) {
            if (vision.collider.tag.Equals("Interactable") && vision.collider.gameObject.TryGetComponent<Interactable>(out Interactable newSelection)) {
                image.color = crosshairSelectColor;

                if (!currentInteractableSelected) {
                    currentInteractableSelected = newSelection;
                    currentInteractableSelected.Select();
                } else if (!newSelection.Equals(currentInteractableSelected)) {
                    currentInteractableSelected.Deselect();
                    currentInteractableSelected = newSelection;
                    currentInteractableSelected.Select();
                }
            } else if (currentInteractableSelected) {
                resetCurrentSelectedInteractable();
            }
        } else if (currentInteractableSelected) {
            resetCurrentSelectedInteractable();
        }
    }

    private void resetCurrentSelectedInteractable() {
        currentInteractableSelected.Deselect();
        currentInteractableSelected = null;
        image.color = crosshairDefaultColor;
    }

    public override void checkUserInteractionInput() {
        if (Input.GetKeyDown(KeyCode.E) && currentInteractableSelected) {
            interact();
        }
    }

    public override void returnToMenu() {
        if (Input.GetKeyDown(KeyCode.M)) {
            game.getGameState().setState(State.RESET_GAME_INTERRUPT);
        }
    }
}