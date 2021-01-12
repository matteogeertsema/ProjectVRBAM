using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularHomeCVEnergyUsage : CVEnergyUsage {

    //Currently not multi-thread safe
    protected override void addAmountOfEnergyConsumed()
    {
        if (temperatureController.getTemperature() >  0 && gameState.getState() == State.PLAYING_BAD_FLOW)
        {
            //if (ThermostatInteractable.OnActivate() = true && gameState.getState() == State.PLAYING_HAPPY_FLOW) {
            gameState.getEnergyConsumption().addAmountConsumedRegularHome(amountOfWatt);
        }
    }
}