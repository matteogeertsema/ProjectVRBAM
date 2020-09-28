using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour {

    [TextArea] public string firstLine;
    [TextArea] public string secondLine;

    public string getFirstLine(){
        return firstLine;
    }

    public string getSecondLine(){
        return secondLine;
    }

}