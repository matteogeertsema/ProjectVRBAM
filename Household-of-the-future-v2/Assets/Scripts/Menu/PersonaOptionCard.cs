using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonaOptionCard : OptionCard {
    private PersonaModel persona;

    public Text personaBiography;
    public Text personaAge;
    public Text personaLimitation;

    public override void onSelectButtonClick() {
        base.onSelectButtonClick();
        game.getGameState().setSelectedPersona(persona);
        game.getGameState().setState(State.CHARACTER_SELECTED);
    }

    public void addInfoToCard(PersonaModel persona) {
        this.persona = persona;

        this.title.text = persona.fullname;
        this.personaBiography.text = persona.biography;

        Rect a = this.personaBiography.rectTransform.rect;
        float height = persona.biography.Length * 1.25f;
        this.personaBiography.rectTransform.sizeDelta = new Vector2(a.width, height);
        Vector3 b = this.personaBiography.rectTransform.transform.position;
        b.y = -(height / 2);
        this.personaBiography.rectTransform.transform.position = b;

        this.personaAge.text = persona.age.ToString();
        this.image.sprite = Resources.Load<Sprite>(persona.photoPath);
        this.image.color = Color.white;

        string limitations = "";
        foreach (string limit in persona.limitations) {
            limitations += limit + "\n";
        }
        this.personaLimitation.text = limitations;
    }
}