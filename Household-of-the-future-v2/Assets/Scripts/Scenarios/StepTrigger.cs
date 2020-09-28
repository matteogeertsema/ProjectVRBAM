using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

/// <summary>
/// Use on a trigger object to make it active a Step
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class StepTrigger : Trigger {

    private void OnTriggerEnter(Collider other) {
        fire();
    }
}