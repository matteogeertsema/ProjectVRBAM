using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartHomeLEDBulbEnergyUsage : LightEnergyUsage {

    //Currently not multi-thread safe
    protected override void addAmountOfEnergyConsumed() {
        if (light.enabled && gameState.getState() == State.PLAYING_HAPPY_FLOW) { 
        gameState.getEnergyConsumption().addAmountConsumedSmartHome(amountOfWatt);
        }
    }
}