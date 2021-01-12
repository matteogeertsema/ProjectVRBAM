using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyConsumption {

    private double amountConsumedInWHRegularHome = 0;
    private double amountConsumedInWHSmartHome = 0;

    public double getAmountConsumedRegularHome() {
        return amountConsumedInWHRegularHome;
    }

    public void addAmountConsumedRegularHome(double amount) {
        this.amountConsumedInWHRegularHome += amount;
        Debug.Log(amountConsumedInWHRegularHome);
    }

    public double getAmountConsumedSmartHome() {
        return amountConsumedInWHSmartHome;
    }

    public void addAmountConsumedSmartHome(double amount) {
        this.amountConsumedInWHSmartHome += amount;
    }

    public void reset() {
        amountConsumedInWHRegularHome = 0;
        amountConsumedInWHSmartHome = 0;
    }
}