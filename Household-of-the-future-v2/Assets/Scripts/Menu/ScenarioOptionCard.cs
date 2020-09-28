using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioOptionCard : OptionCard {
    private ScenarioModel scenario;

    public override void onSelectButtonClick() {
        base.onSelectButtonClick();
        game.getGameState().setSelectedScenario(scenario);
        game.getGameState().setState(State.SCENARIO_SELECTED);
    }

    public void addInfoToCard(ScenarioModel scenario) {
        this.scenario = scenario;
        this.title.text = scenario.name;
        this.image.sprite = Resources.Load<Sprite>(scenario.imagePath);
        this.image.color = Color.white;
    }
}