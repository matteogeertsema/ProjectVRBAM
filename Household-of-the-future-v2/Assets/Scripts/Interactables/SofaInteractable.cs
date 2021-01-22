using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SofaInteractable : Interactable
{
    public Transform onTheSofaLocation;
    public Transform offTheSofaLocation;
    private Player player;
    private AudioPlayer audioPlayer;
    //  private Transform locationBeforeSittingOnSofa;
    //private Audio liftmuziekje

    // Start is called before the first frame update
    public override void OnStart()
    {
        player = FindObjectOfType<PlayerController>().getPlayer();
        {
            audioPlayer = GameObject.FindObjectOfType<AudioPlayer>();
            if (!audioPlayer)
            {
                Debug.LogError("No instance of Audioplayer found");
            }
        }
    }

    // Is called when a sofa is clicked
    public override void OnActivate()
    {
        sitOnSofa();  
    }

    // Transport player to given position and disable controls
    // Duration is 32 sec to sync with music and timestep in IR heating
    private void sitOnSofa()
    {
        //  locationBeforeSittingOnSofa = player.GetComponent<Transform>();
        player.transform.SetPositionAndRotation(onTheSofaLocation.transform.position, onTheSofaLocation.transform.rotation);
        player.disablePlayerControls();

        this.GetComponent<BoxCollider>().isTrigger = true;
        StartCoroutine(waitAmoutOfSeconds(32));
        if (audioPlayer)
        {
            audioPlayer.play("WaitMusic");
        }
    }

    // Calls getOffSofa after a amount of seconds
    // In those amount of seconds player can also press q to get off sofa
    IEnumerator waitAmoutOfSeconds(int amountInSeconds)
    {
        for (float i = 0; i <= amountInSeconds; i += Time.deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                getOffSofa();
                break; 
            }
            yield return null;
        }
       
        getOffSofa();
    }

    //Transport player to given position and enable controls
    private void getOffSofa()
    {

        player.transform.SetPositionAndRotation(offTheSofaLocation.transform.position, offTheSofaLocation.transform.rotation);
        player.enablePlayerControls();
        if (audioPlayer)
        {
            audioPlayer.play("Silent");
        }
    }

    public override bool isActive()
    {
        return false;
    }

    public override void OnUpdate()
    {

    }

    public override void OnSelect()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnDeselect()
    {
        //throw new System.NotImplementedException();
    }
}