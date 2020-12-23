using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfraredController : MonoBehaviour
{
    public string controllerName = "Placeholder";
    private bool isWorking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void infraredOn()
    {
        print("Infrarood aan");
    }

    public void infraredoff()
    {
        print("Infrarood uit");
    }

    public bool isOn()
    {
        return isWorking;
    }
}
