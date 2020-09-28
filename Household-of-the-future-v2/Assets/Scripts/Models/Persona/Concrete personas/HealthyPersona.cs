using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyPersona : PersonaModel {

    public HealthyPersona() {
        this.fullname = "Marieke Weerts";
        this.age = 68;
        this.photoPath = "Persona/marieke";
        this.biography = "";
        this.limitations = new string[1] { "Geen" };
        this.hearing = new OptimalHearing();
        this.eyesight = new OptimalEyesight();
        this.movement = new OptimalMovement();
    }

}