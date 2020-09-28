using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadMovementPersona : PersonaModel {

    public BadMovementPersona() {
        this.fullname = "Karin Veenstra";
        this.age = 65;
        this.photoPath = "Persona/Karin";
        this.biography = "Karin is 65 jaar oud.\nZe woont bij haar man Peter in Groningen.\nDoor een ongeval een tijdje geleden heeft ze rugklachten gekregen.\nDit maakt het verplaatsen door het huis veel moeilijker.";
        this.limitations = new string[1] { "Slechte rug" };
        this.hearing = new OptimalHearing();
        this.eyesight = new OptimalEyesight();
        this.movement = new BadMovement();
    }

}