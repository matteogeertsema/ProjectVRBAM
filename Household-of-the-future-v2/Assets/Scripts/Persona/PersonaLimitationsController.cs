using System.Collections;
using System.Collections.Generic;
using SuperBlur;
using UnityEngine;
using UnityEngine.UI;

public class PersonaLimitationsController : MonoBehaviour {

    private Game game;
    private Settings sceneSettings;
    private Player player;
    private AudioSource[] audioSources;
    private SuperBlurBase cameraBlur;

    private void Awake() {
        game = GameObject.FindObjectOfType<Game>();
        sceneSettings = GameObject.FindObjectOfType<Settings>();
        player = GameObject.FindObjectOfType<Player>();
        audioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        cameraBlur = GameObject.FindObjectOfType<SuperBlurBase>();
    }

    private void Start() {
        PersonaModel persona = (game && !sceneSettings.getIsDebugMode()) ? game.getGameState().getSelectedPersona() : new HealthyPersona();
        checkForLimitations(persona);
    }

    private void checkForLimitations(PersonaModel persona) {
        float movementStrength = persona.getMovement().getStrength();
        float eyesightStrength = persona.getEyesight().getStrength();
        float hearingStrength = persona.getHearing().getStrength();

        if (movementStrength < 1f) {
            applyMovementDisability(movementStrength);
        }
        if (hearingStrength < 1f) {
            applyHearingDisability(hearingStrength);
        }
        if (eyesightStrength < 1f) {
            applyEyesightDisability(eyesightStrength);
        }

    }

    private void applyMovementDisability(float value) {
        player.setSpeed(value);
    }

    private void applyHearingDisability(float value) {
        for (int i = 0; i < audioSources.Length; i++) {
            audioSources[i].volume = value;
        }
    }

    private void applyEyesightDisability(float value) {
        cameraBlur.enabled = true;
    }
}