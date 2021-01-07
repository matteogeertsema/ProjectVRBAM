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

    }

    public override void OnActivate()
    {
        sitOnSofa();

        if (audioPlayer)
            {
                audioPlayer.play("WaitMusic");
            }
        

    }

    private void sitOnSofa()
    {
      //  locationBeforeSittingOnSofa = player.GetComponent<Transform>();
        player.transform.SetPositionAndRotation(onTheSofaLocation.transform.position, onTheSofaLocation.transform.rotation);
        player.disablePlayerControls();

        this.GetComponent<BoxCollider>().isTrigger = true;
        isSittingOnTheSofa = true;
        StartCoroutine(waitAmoutOfSeconds(20));

    }

    IEnumerator waitAmoutOfSeconds(int amountInSeconds)
    {
        for (float i = 0; i <= amountInSeconds; i += Time.deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
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