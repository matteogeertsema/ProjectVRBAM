using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Player vrPlayer;
    public Player editorPlayer;

    public Player activePlayer;

    private void Awake() {
        if (Application.isEditor) {
            setEditorPlayerAsActivePlayer();
        } else {
            setVRPlayerAsActivePlayer();
        }
    }

    private void setEditorPlayerAsActivePlayer() {
        Debug.Log("setEditorPlayerAsActivePlayer");
        activePlayer = editorPlayer;
        vrPlayer.gameObject.SetActive(false);
    }

    private void setVRPlayerAsActivePlayer() {
        Debug.Log("setVRPlayerAsActivePlayer");
        activePlayer = vrPlayer;
        editorPlayer.gameObject.SetActive(false);
    }

    public Player getPlayer() {
        return activePlayer;
    }
}