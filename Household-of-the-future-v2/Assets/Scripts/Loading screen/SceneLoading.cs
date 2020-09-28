using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour {

    private SmarthomeFacts facts;

    [SerializeField]
    private Text randomText;

    [SerializeField]
    private Image loadingBar;

    private void Awake() {
        facts = new SmarthomeFacts();
    }

    public void startScene(string name) {
        StartCoroutine(loadScene(name));
    }

    public void loadRegularHomeScene() {
        StartCoroutine(loadScene("Regular Household"));
    }

    public void loadSmartHomeScene() {
        StartCoroutine(loadScene("BamHouse"));
    }

    public void loadMenuScene() {
        StartCoroutine(loadScene("MenuScene"));
    }

    private IEnumerator loadScene(string sceneName) {
        randomText.text = facts.getRandomFact();
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone) {
            loadingBar.fillAmount = async.progress;
            yield return new WaitForEndOfFrame();
        }
    }

}