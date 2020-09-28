using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour {

    private static Game instance;
    private GameState gameState;
    private CurvedMenuController menu;
    private AudioPlayer audioPlayer;
    private GameRepository repository;
    private SelectionBar selectionBar;

    private Game() { }

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        repository = new GameRepository();
        gameState = new GameState();
        audioPlayer = GameObject.FindObjectOfType<AudioPlayer>();
    }

    private void Start() {
        gameState.setState(State.READY);
    }

    private void setReferencesInMenuScene() {
        menu = GameObject.FindObjectOfType<CurvedMenuController>();
        selectionBar = GameObject.FindObjectOfType<SelectionBar>();
    }

    private void Update() {
        if (gameState == null)
            return;

        switch (gameState.getState()) {
            case State.BUILD_MENU_SCENE:
                setReferencesInMenuScene();
                menu.createAllCards();
                menu.deactivateAllCardOptions();
                gameState.setState(State.START_MENU);
                break;
            case State.START_MENU:
                displayScenarioOptions();
                break;
            case State.SCENARIO_SELECTED:
                placeScenarioInSelectionBar();
                menu.deactivateScenarioOptions();
                displayPersonaOptions();
                break;
            case State.CHARACTER_SELECTED:
                placePersonaInSelectionBar();
                menu.deactivatePersonaOptions();
                startScenarioFlowBasedOn(gameState.getSelectedScenario());
                break;
            case State.BAD_FLOW_ENDED:
                startScenarioHappyFlow();
                break;
            case State.RESET_MENU_OPTIONS:
                menu.deactivateAllCardOptions();
                gameState.setState(State.START_MENU);
                break;
            case State.HAPPY_FLOW_ENDED:
            case State.RESET_GAME_INTERRUPT:
                gameOver();
                break;
        }
    }

    private void startScenarioFlowBasedOn(ScenarioModel selectedScenario) {
        if (selectedScenario is NoScenarioModel)
            startScenarioHappyFlow();
        else
            startScenarioBadFlow();
    }

    private void placeScenarioInSelectionBar() {
        ScenarioModel scenario = gameState.getSelectedScenario();
        selectionBar.setScenarioCardInSelectionBar(scenario.imagePath, scenario.name);
    }

    private void placePersonaInSelectionBar() {
        PersonaModel persona = gameState.getSelectedPersona();
        selectionBar.setPersonaCardInSelectionBar(persona.photoPath, persona.fullname);
    }

    private void displayScenarioOptions() {
        gameState.setState(State.PICKING_SCENARIO);
        audioPlayer.play("menu-scenario");
        menu.displayScenarioOptions();
    }

    private void displayPersonaOptions() {
        gameState.setState(State.PICKING_CHARACTER);
        audioPlayer.play("menu-persona");
        menu.displayPersonaOptions();
    }

    private void startScenarioBadFlow() {
        gameState.setState(State.STARTING_BAD_FLOW);
        StartCoroutine(loadScene("Regular Household"));
    }

    private void startScenarioHappyFlow() {
        gameState.setState(State.STARTING_HAPPY_FLOW);
        StartCoroutine(loadScene("BamHouse"));
    }

    private void gameOver() {
        StartCoroutine(loadScene("MenuScene"));
        gameState.reset();
    }

    public GameState getGameState() {
        return gameState;
    }

    public AudioPlayer getAudioPlayer() {
        return audioPlayer;
    }

    public GameRepository getRepository() {
        return repository;
    }

    private IEnumerator loadScene(string sceneName) {
        AsyncOperation async = SceneManager.LoadSceneAsync("LoadingScene");

        while (!async.isDone) {
            yield return new WaitForEndOfFrame();
        }

        GameObject.FindObjectOfType<SceneLoading>().startScene(sceneName);
    }

}