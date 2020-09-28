using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadHearingPersona : PersonaModel {

    public BadHearingPersona() {
        this.fullname = "Daan Geerlink";
        this.age = 73;
        this.photoPath = "Persona/johan";
        this.biography = "";
        this.limitations = new string[1] { "Slecht gehoor" };
        this.hearing = new BadHearing();
        this.eyesight = new OptimalEyesight();
        this.movement = new OptimalMovement();
    }

}