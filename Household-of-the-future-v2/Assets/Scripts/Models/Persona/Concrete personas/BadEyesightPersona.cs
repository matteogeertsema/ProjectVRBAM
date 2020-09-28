using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEyesightPersona : PersonaModel {

    public BadEyesightPersona() {
        this.fullname = "Aart Dubbink";
        this.age = 78;
        this.photoPath = "Persona/Aart";
        this.biography = ""; 
        this.limitations = new string[1] { "Glaucoom" };
        this.hearing = new OptimalHearing();
        this.eyesight = new BadEyesight();
        this.movement = new OptimalMovement();
    }

}