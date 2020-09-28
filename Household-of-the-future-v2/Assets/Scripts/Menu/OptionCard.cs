using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class OptionCard : MonoBehaviour {
    public Text title;
    public Image image;

    protected Game game;

    void Awake() {
        game = GameObject.FindObjectOfType<Game>();
    }

    public virtual void onSelectButtonClick() {
        game.getAudioPlayer().play("ButtonClick");
    }
}