using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {
    READY, // Game is ready with to receive state changes.
    BUILD_MENU_SCENE,
    START_MENU,
    PICKING_SCENARIO,
    SCENARIO_SELECTED,
    PICKING_CHARACTER,
    CHARACTER_SELECTED,
    STARTING_BAD_FLOW,
    PLAYING_BAD_FLOW,
    BAD_FLOW_ENDED,
    WAITING,
    STARTED,
    RUNNING,
    COMPLETED,
    STARTING_HAPPY_FLOW,
    BUILD_SCENARIO_SCENE,
    PLAYING_HAPPY_FLOW,
    HAPPY_FLOW_ENDED,
    PROMPT_OUTRO,
    RESET_GAME_INTERRUPT,
    RESET_MENU_OPTIONS
}