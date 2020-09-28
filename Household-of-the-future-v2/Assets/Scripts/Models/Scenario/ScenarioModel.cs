using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScenarioModel {
    public int id;
    public string name;
    public string imagePath;

    protected ScenarioModel(int id, string name, string path) {
        this.id = id;
        this.name = name;
        this.imagePath = path;
    }
}