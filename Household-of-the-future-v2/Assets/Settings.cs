using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    [SerializeField]
    private bool isSmartHome;

    [SerializeField]
    private bool isDebugMode;

    public bool getIsSmartHome() {
        return isSmartHome;
    }

    public bool getIsDebugMode() {
        return isDebugMode;
    }

}