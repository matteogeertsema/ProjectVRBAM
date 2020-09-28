using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Put on a trigger object to activate a Light controller.
/// Turns lights on when player enters trigger, turns lights of after waitTime has expired.
/// 
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class LightSensor : MonoBehaviour{
    public LightController lightController;
    public float marginTimeInSeconds = 3.0f;

    private float timeWhenUserLeftInSeconds;
    private bool userLeftTheRoom;

    // Update is called once per frame
    void Update(){
        if (userLeftTheRoom && Time.time > (timeWhenUserLeftInSeconds + marginTimeInSeconds)){
            lightController.TurnOff();
            userLeftTheRoom = false;
        }
    }

    private void OnTriggerEnter(Collider other){
        lightController.TurnOn();
        userLeftTheRoom = false;

        Debug.Log("entered the room: " + name);
    }

    private void OnTriggerExit(Collider other){
        timeWhenUserLeftInSeconds = Time.time;
        userLeftTheRoom = true;

        Debug.Log("Left the room: " + name);
    }
}
