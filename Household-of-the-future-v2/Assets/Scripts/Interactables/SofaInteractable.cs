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

    private bool isSittingOnTheSofa = false;


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

    public override void OnActivate()
    {
       

        sitOnSofa();
        
    }

    private void sitOnSofa()
    {
        //  locationBeforeSittingOnSofa = player.GetComponent<Transform>();



        player.transform.SetPositionAndRotation(onTheSofaLocation.transform.position, onTheSofaLocation.transform.rotation);
        player.disablePlayerControls();

        this.GetComponent<BoxCollider>().isTrigger = true;
        isSittingOnTheSofa = true;
        StartCoroutine(waitAmoutOfSeconds(32));
        if (audioPlayer)
        {
            audioPlayer.play("WaitMusic");
        }




    }

    IEnumerator waitAmoutOfSeconds(int amountInSeconds)
    {
        for (float i = 0; i <= amountInSeconds; i += Time.deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                getOffSofa();
                break;
                

            }
            yield return null;
        }
       
        getOffSofa();
    }

    private void getOffSofa()
    {

        player.transform.SetPositionAndRotation(offTheSofaLocation.transform.position, offTheSofaLocation.transform.rotation);
        player.enablePlayerControls();
        isSittingOnTheSofa = false;
        if (audioPlayer)
        {
            audioPlayer.play("Silent");
        }

    }

    public override bool isActive()
    {
        return isSittingOnTheSofa;
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