using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LightEnergyUsage : MonoBehaviour {

    private Game game;
    protected GameState gameState;
    protected Light light;
    public double amountOfWatt = 8;

    private void Start() {
        setReferences();
        if (isReferencesSet()) {
            InvokeRepeating("addAmountOfEnergyConsumed", 1f, 1f); // perform addAmountOfEnergyConsumed every 1 second.
        } else {
            Debug.LogError("One or more references are not assigned.");
        }
    }

    private void setReferences() {
        game = GameObject.FindObjectOfType<Game>();
        gameState = game.getGameState();
        light = GetComponent<Light>();
    }

    private bool isReferencesSet() {
        return isGameSet() && isGameStateSet() && isLightSet();
    }

    private bool isGameSet() {
        return game != null;
    }

    private bool isGameStateSet() {
        return gameState != null;
    }

    private bool isLightSet() {
        return light != null;
    }

    protected abstract void addAmountOfEnergyConsumed();
}