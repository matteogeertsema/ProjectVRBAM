using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outro : MonoBehaviour {

    [TextArea] public string firstLine;
    [TextArea] public string secondLine;
    [TextArea] public string thirdLine;

    private GameState gameState;
    private EnergyConsumption energyConsumption;
    private Settings sceneSettings;

    private void Awake() {
        sceneSettings = FindObjectOfType<Settings>();
    }

    private void Start() {
        gameState = GameObject.FindObjectOfType<Game>().getGameState();
        energyConsumption = gameState.getEnergyConsumption();
    }

    public string getFirstLine() {
        return firstLine;
    }

    public string getSecondLine() {
        return secondLine;
    }

    public string getThirdLine() {
        return "Uw speeltijd was: " + gameState.getTimeElapsedSinceScenarioStart() + " seconden. " + (sceneSettings.getIsSmartHome() ? createFinalLineForSmartHome() : createFinalLineForRegularHome());
    }

    private string createFinalLineForSmartHome() {
        double energyConsumedRegularHome = energyConsumption.getAmountConsumedRegularHome();
        double energyConsumedSmartHome = energyConsumption.getAmountConsumedSmartHome();
        double energyConsumedInKWh = energyConsumedSmartHome / (1000 * 3600);
        double energyConsumedOverAYear = Math.Round(energyConsumedInKWh * 365, 2);
        double energyCostsAYear = Math.Round(energyConsumedOverAYear * 0.22, 2); // Gemiddelde energieprijs 2020 = 0.22 euro per 1 kWh.
        double energySaved = Math.Round(energyConsumedRegularHome / energyConsumedSmartHome, 2);
        return "In de scenario heeft u op jaarbasis " + energyConsumedOverAYear + " kWh aan energie verbruikt. Dit komt uit op €" + energyCostsAYear + " (0,22 euro per 1 kWh). Dat is " + energySaved + " keer minder dan wat u in de gewone woning heeft verbruikt.";
    }

    private string createFinalLineForRegularHome() {
        double energyConsumed = energyConsumption.getAmountConsumedRegularHome();
        double energyConsumedInKWh = energyConsumed / (1000 * 3600);
        double energyConsumedOverAYear = Math.Round(energyConsumedInKWh * 365, 2);
        double energyCostsAYear = Math.Round(energyConsumedOverAYear * 0.22, 2); // Gemiddelde energieprijs 2020 = 0.22 euro per 1 kWh.
        return "In de scenario heeft u op jaarbasis " + energyConsumedOverAYear + " kWh aan energie verbruikt. Dit komt uit op €" + energyCostsAYear + " (0,22 euro per 1 kWh).";
    }

}