using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioScene : MonoBehaviour {
    private GameState gameState;

    private void Start() {
        gameState = FindObjectOfType<Game>().getGameState();
    }

    // private void Update() {
    //     if (gameState == null) return;

    //     switch (gameState.getState()) {
    //         case State.READY:
    //         case State.STARTING_HAPPY_FLOW:
    //             gameState.setState(State.BUILD_SCENARIO_SCENE);
    //             break;
    //     }
    // }
}