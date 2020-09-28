using System.Collections;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

/// <summary>
/// A step that is completed by activating one interactable in the list of activators
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public class ActivateStep : Step {

    public List<Trigger> triggers;

    public override void OnActivate() {
        state = State.COMPLETED;
    }

    public override void OnRun() { }

    public override void OnStart() {
        giveActivatorsStepReference();
    }

    public override void OnUpdate() {

    }

    private void giveActivatorsStepReference() {
        foreach (Trigger trigger in triggers) {
            StepHandler stepHandler = trigger.GetComponent<StepHandler>();
            stepHandler.AddStep(this);
        }
    }
}