using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : MonoBehaviour {

    private GameState gameState;

    private void Start() {
        gameState = FindObjectOfType<Game>().getGameState();
    }

    private void Update() {
        if(gameState == null) return;

        switch (gameState.getState()) {
            case State.READY:
                gameState.setState(State.BUILD_MENU_SCENE);
                break;
        }
    }
}