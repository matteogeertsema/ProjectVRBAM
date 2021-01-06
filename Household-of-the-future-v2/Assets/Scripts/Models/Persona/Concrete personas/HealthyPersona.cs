using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyPersona : PersonaModel {

    public HealthyPersona() {
        this.fullname = "Marieke Weerts";
        this.age = 40;
        this.photoPath = "Persona/marieke";
        this.biography = "Marieke wil haar huis transformeren naar een smart home. Ze heeft zonnepanelen aangeschaft en wil energie besparen op verwarmen door middel van domotica";
        this.limitations = new string[1] { "Geen" };
        this.hearing = new OptimalHearing();
        this.eyesight = new OptimalEyesight();
        this.movement = new OptimalMovement();
    }

}