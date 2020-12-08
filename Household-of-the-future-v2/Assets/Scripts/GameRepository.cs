using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRepository {

    private ScenarioModel[] scenarios = new ScenarioModel[3];
    private PersonaModel[] personas = new PersonaModel[4];

    public GameRepository() {
        createScenarios();
        createPersonas();
    }

    private void createScenarios() {
        scenarios[1] = new BathroomAtNightModel();
        scenarios[0] = new IRHeatingModel();
        // scenarios[1] = new StuckOnToiletModel();
        scenarios[2] = new NoScenarioModel();
    }

    private void createPersonas() {
        personas[0] = new HealthyPersona();
        personas[1] = new BadMovementPersona();
        personas[2] = new BadEyesightPersona();
        personas[3] = new BadHearingPersona();
    }

    public ScenarioModel[] getScenarios() {
        return scenarios;
    }

    public PersonaModel[] getPersonas() {
        return personas;
    }

}