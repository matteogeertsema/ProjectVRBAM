using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PersonaModel {

    public string fullname;
    public int age;
    public string photoPath;

    public string biography;
    public string[] limitations;

    protected Hearing hearing;
    protected Eyesight eyesight;
    protected Movement movement;

    public Hearing getHearing() {
        return hearing;
    }

    public Eyesight getEyesight() {
        return eyesight;
    }

    public Movement getMovement() {
        return movement;
    }
}