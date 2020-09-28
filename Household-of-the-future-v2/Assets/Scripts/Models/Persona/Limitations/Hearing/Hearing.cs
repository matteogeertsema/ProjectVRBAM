using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hearing {
    private float strength;

    protected Hearing(float value) {
        if (value > 1f && value < 0f) {
            return;
        }
        this.strength = value;
    }

    public float getStrength() {
        return strength;
    }
}