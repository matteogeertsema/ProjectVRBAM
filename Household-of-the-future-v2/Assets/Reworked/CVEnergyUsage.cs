using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CVEnergyUsage : MonoBehaviour
{

    private Game game;
    protected GameState gameState;
    public double amountOfWatt = 10;
    public TemperatureController temperatureController;
   

    private void Start()
    {
        
        if (isReferencesSet())
        {
            InvokeRepeating("addAmountOfEnergyConsumed", 1f, 1f); // perform addAmountOfEnergyConsumed every 1 second.
            
        }
        else
        {
            Debug.LogError("One or more references are not assigned.");
        }
    }

    private void setReferences() {
        game = GameObject.FindObjectOfType<Game>();
        gameState = game.getGameState(); 
        
    } 

    private bool isReferencesSet() {
        return isGameSet() && isGameStateSet();
    }

    private bool isGameSet() {
        return game != null;
    }

    private bool isGameStateSet() {
        return gameState != null;
    }

    protected abstract void addAmountOfEnergyConsumed();
}
