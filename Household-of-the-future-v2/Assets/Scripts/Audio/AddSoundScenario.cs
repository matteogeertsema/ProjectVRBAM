using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSoundScenario : MonoBehaviour {
    public string audioName;
    public bool playAtIntro = false;
    public bool playAtOutro = false;
    public float delayInSeconds = 0.0f;
    private float startTime = 0.0f;

    private Scenario scenario;
    private AudioPlayer audioPlayer;

    void Start() {
        scenario = GetComponent<Scenario>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Update() {
        if (!audioPlayer || !scenario) {
            return;
        }

        if ((playAtIntro && scenario.hasScenarioStarted()) || (playAtOutro && scenario.isScenarioDone())) {
            if (!hasTimerStarted()) {
                startTimer();
            }

            if (delayInSecondsIsMet()) {
                if (playAtIntro) {
                    playSongAtIntro();
                } else {
                    playSongAtOutro();
                }
                resetTimer();
            }
        }
    }

    private void playSongAtIntro() {
        audioPlayer.play(audioName);
        playAtIntro = false;
    }

    private void playSongAtOutro() {
        audioPlayer.play(audioName);
        playAtOutro = false;
    }

    private void resetTimer() {
        startTime = 0.0f;
    }

    private void startTimer() {
        startTime = Time.time;
    }

    private bool hasTimerStarted() {
        return startTime != 0.0f;
    }

    private bool delayInSecondsIsMet() {
        return startTime + delayInSeconds <= Time.time;
    }
}