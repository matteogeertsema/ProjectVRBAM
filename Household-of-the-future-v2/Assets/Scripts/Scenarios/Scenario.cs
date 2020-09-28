using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour {

    public Transform startLocation;
    public string title;
    public Introduction intro;
    public Outro outro;
    public List<Step> steps;
    public bool startWithOpenCurtains;
    public bool startWithLightsOn;
    public TimeOfDayManager.DayPart timeOfDay;

    private int activeStepIndex = 0;
    private Step currentStep;

    private void setTimeOfDay() {
        GameObject.FindObjectOfType<TimeOfDayManager>().setDayPart(timeOfDay);
    }

    private void applyDomoticsControllerSettings() {
        DomoticaController domoticsController = GameObject.FindObjectOfType<DomoticaController>();
        domoticsController.SwitchCurtainsWithoutAnimation(startWithOpenCurtains);
        domoticsController.SwitchLights(startWithLightsOn);
    }

    private void applyStartingPositionToPlayer() {
        GameObject player = FindObjectOfType<PlayerController>().getPlayer().gameObject;
        player.transform.SetPositionAndRotation(startLocation.transform.position, startLocation.transform.rotation);
    }

    public void beginScenario() {
        applyDomoticsControllerSettings();
        setTimeOfDay();
        applyStartingPositionToPlayer();
        currentStep = steps[0];
    }

    public Introduction getIntro() {
        return this.intro;
    }

    public Outro getOutro() {
        return this.outro;
    }

    public string getTitle() {
        return this.title;
    }

    public bool hasNextStep() {
        return activeStepIndex + 1 < steps.Count;
    }

    public void nextStep() {
        activeStepIndex++;
        currentStep = steps[activeStepIndex];
        currentStep.Run();
    }

    public string getCurrentStepObjective() {
        return this.currentStep.GetStepName();
    }

    public bool stepCompleted() {
        return currentStep && currentStep.getState() == State.COMPLETED;
    }

    public bool hasScenarioStarted() {
        return currentStep;
    }

    public bool isScenarioDone() {
        return stepCompleted() && !hasNextStep();
    }
}