using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioController : MonoBehaviour {

    [SerializeField]
    private GameObject informationPoints;

    [SerializeField]
    private Scenario[] scenarios;

    [SerializeField]
    private Scenario debugScenario; // When in debug mode, set the index of the scenario you want to play.

    private DomoticaController domoticsController;
    private UIHandler UIHandler;
    private ScenarioModel activeScenarioModel;
    private Scenario activeScenario; // The scenario that is to be played.
    private GameState gameState;
    private EnergyConsumption energyConsumption;
    private Player player;
    private Settings sceneSettings;

    private void Awake() {
        sceneSettings = FindObjectOfType<Settings>();
        domoticsController = FindObjectOfType<DomoticaController>();
        player = FindObjectOfType<PlayerController>().getPlayer();
        UIHandler = FindObjectOfType<UIHandler>();
    }

    private void Start() {
        gameState = FindObjectOfType<Game>().getGameState();
        energyConsumption = gameState.getEnergyConsumption();

        activeScenarioModel = fetchSelectedScenarioModelIf(!sceneSettings.getIsDebugMode());
        enableInformationPointsIf((activeScenarioModel is NoScenarioModel));
        activeScenario = determineActiveScenario();
        player.disablePlayerControls();
        displayIntroduction();
    }

    private void Update() {
        switch (gameState.getState()) {
            case State.PLAYING_HAPPY_FLOW:
            case State.PLAYING_BAD_FLOW:
                if (activeScenario.stepCompleted()) {
                    determineNextStep();
                }
                break;
        }
    }

    private void determineNextStep() {
        if (activeScenario.hasNextStep()) {
            goToNextStep();
        } else {
            onScenarioFinished();
        }
    }

    private void enableInformationPointsIf(bool enableInformationPoints) {
        if (enableInformationPoints) {
            informationPoints.SetActive(true);
        }
    }

    private Scenario determineActiveScenario() {
        return sceneSettings.getIsDebugMode() ? debugScenario : scenarios[activeScenarioModel.id];
    }

    private ScenarioModel fetchSelectedScenarioModelIf(bool isNotDebugMode) {
        return isNotDebugMode ? gameState.getSelectedScenario() : null;
    }

    private void onScenarioFinished() {
        CancelInvoke();
        player.disablePlayerControls();
        displayOutro();
    }

    private void displayIntroduction() {
        UIHandler.displayIntro(activeScenario.getTitle(), activeScenario.getIntro());
    }

    private void displayOutro() {
        gameState.setState(State.PROMPT_OUTRO);
        UIHandler.displayOutro(activeScenario.getOutro());
    }

    private void goToNextStep() {
        activeScenario.nextStep();
        setNewObjectiveOnUI(activeScenario.getCurrentStepObjective());
    }

    public void startScenario() {
        setGameStateToPlaying();
        gameState.resetElapsedSinceScenarioStartTimer();
        InvokeRepeating("startElapsedPlaytimeTimer", 1f, 1f); //1s delay, repeat every 1s
        player.enablePlayerControls();
        activeScenario.beginScenario();
        setNewObjectiveOnUI(activeScenario.getCurrentStepObjective());
    }

    private void startElapsedPlaytimeTimer() {
        gameState.addToTimeElapsedSinceScenarioStart(1);
    }

    private void setNewObjectiveOnUI(string objective) {
        UIHandler.setNewObjective(objective);
    }

    private void setGameStateToPlaying() {
        State state = sceneSettings.getIsSmartHome() ? State.PLAYING_HAPPY_FLOW : State.PLAYING_BAD_FLOW;
        gameState.setState(state);
    }

    private void setGameStateToEnded() {
        State state = sceneSettings.getIsSmartHome() ? State.HAPPY_FLOW_ENDED : State.BAD_FLOW_ENDED;
        gameState.setState(state);
    }

    public void onOutroButtonClick() {
        setGameStateToEnded();
    }
}