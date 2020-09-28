using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState {
    private State currentState;
    private ScenarioModel selectedScenario;
    private PersonaModel selectedPersona;
    private EnergyConsumption energyConsumption;
    private float timeElapsedSinceScenarioStart = 0f;

    public GameState() {
        energyConsumption = new EnergyConsumption();
    }

    public State getState() {
        return currentState;
    }

    public void setState(State newState) {
        Debug.Log("new state is: " + newState);
        this.currentState = newState;
    }

    public void reset() {
        selectedScenario = null;
        selectedPersona = null;
        energyConsumption.reset();
        currentState = State.READY;
    }

    public ScenarioModel getSelectedScenario() {
        return selectedScenario;
    }

    public void setSelectedScenario(ScenarioModel scenario) {
        this.selectedScenario = scenario;
    }

    public PersonaModel getSelectedPersona() {
        return selectedPersona;
    }

    public void setSelectedPersona(PersonaModel persona) {
        this.selectedPersona = persona;
    }

    public EnergyConsumption getEnergyConsumption() {
        return energyConsumption;
    }

    public float getTimeElapsedSinceScenarioStart() {
        return timeElapsedSinceScenarioStart;
    }

    public void addToTimeElapsedSinceScenarioStart(float amount) {
        this.timeElapsedSinceScenarioStart += amount;
    }

    public void resetElapsedSinceScenarioStartTimer(){
        this.timeElapsedSinceScenarioStart = 0f;
    }

}