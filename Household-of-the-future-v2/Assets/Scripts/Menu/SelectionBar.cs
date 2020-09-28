using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionBar : MonoBehaviour {

    public GameObject selectedScenarioSlot;
    public GameObject selectedPersonaSlot;

    private Game game;

    private void Start() {
        game = GameObject.FindObjectOfType<Game>();
    }

    public void setScenarioCardInSelectionBar(string imgPath, string description) {
        Sprite img = Resources.Load<Sprite>(imgPath);
        selectedScenarioSlot.GetComponent<CurrentSelected>().FillCurrentSelected(img, description, Color.white);
    }

    public void setPersonaCardInSelectionBar(string imgPath, string description) {
        Sprite img = Resources.Load<Sprite>(imgPath);
        selectedPersonaSlot.GetComponent<CurrentSelected>().FillCurrentSelected(img, description, Color.white);
    }

    public void onResetButtonClick() {
        game.getAudioPlayer().play("ButtonClick");
        selectedScenarioSlot.GetComponent<CurrentSelected>().Reset();
        selectedPersonaSlot.GetComponent<CurrentSelected>().Reset();
        game.getGameState().setState(State.RESET_MENU_OPTIONS);
    }
}