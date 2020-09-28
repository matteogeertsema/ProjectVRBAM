using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularHomeLightBulbEnergyUsage : LightEnergyUsage {

    //Currently not multi-thread safe
    protected override void addAmountOfEnergyConsumed() {
        if (light.enabled && gameState.getState() == State.PLAYING_BAD_FLOW) {
            gameState.getEnergyConsumption().addAmountConsumedRegularHome(amountOfWatt);
        }
    }
}