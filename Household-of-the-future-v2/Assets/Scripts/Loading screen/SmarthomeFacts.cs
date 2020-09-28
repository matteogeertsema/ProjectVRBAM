using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using OVRSimpleJSON;
using UnityEngine;

public class SmarthomeFacts {

    public TextAsset jsonFile;
    private JSONNode info;
    private Fact[] facts;

    public SmarthomeFacts() {
        loadAndParseJSONContent("smarthome-facts");
    }

    private void loadAndParseJSONContent(string fileName) {
        TextAsset textfromfile = Resources.Load<TextAsset>(fileName);
        if (textfromfile != null) {
            using(StreamReader sr = new StreamReader(new MemoryStream(textfromfile.bytes))) {
                string json = sr.ReadToEnd();
                info = JSON.Parse(json);

                facts = JsonHelper.getJsonArray<Fact>(info["facts"].ToString());
                sr.Close();
            }
        }
    }

    public string getRandomFact() {
        int randomVal = (int) UnityEngine.Random.Range(0.0f, facts.Length - 1);
        return facts[randomVal].fact;
    }

    [Serializable]
    public struct Fact {
        //employees is case sensitive and must match the string "employees" in the JSON.
        public string fact;
    }
}