using System;
using System.Collections.Generic;
using cakeslice;
using UnityEngine;

/// <summary>
/// This is the abstract class of all interactables.
/// It adds an outline on the object that is interactable.
/// To create an interactable dont forget to give it a interactable tag.
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public abstract class Interactable : Trigger {

    private List<Renderer> rendererList;
    private bool isCurrentlySelected;
    private Material selectedObjectMaterial;

    public abstract void OnActivate();
    public abstract void OnSelect();
    public abstract void OnDeselect();
    public abstract void OnStart();
    public abstract void OnUpdate();
    public abstract bool isActive();

    protected override void Awake() {
        base.Awake();
        rendererList = new List<Renderer>();
        selectedObjectMaterial = Resources.Load("Materials/OutlineMaterial", typeof(Material)) as Material;
    }

    private void Start() {
        gatherAllRendererComponents();
        removeSelectionMaterial();
        OnStart();
    }

    private void Update() {
        this.OnUpdate();
    }

    private void gatherAllRendererComponents() {
        Renderer thisObjectRenderer = this.gameObject.GetComponent<Renderer>();

        if (thisObjectRenderer) {
            rendererList.Add(thisObjectRenderer);
        }

        foreach (Renderer childObjectRenderer in GetComponentsInChildren<Renderer>()) {
            rendererList.Add(childObjectRenderer);
        }
    }

    public void Select() {
        applySelectionMaterial();
    }

    public void Deselect() {
        removeSelectionMaterial();
    }

    public void Activate() {
        OnActivate();
        base.fire();
    }

    private void applySelectionMaterial() {
        if (isCurrentlySelected) return;

        foreach (Renderer renderer in rendererList) {
            Material[] materials = renderer.materials;
            Array.Resize(ref materials, materials.Length + 1);

            materials[materials.Length - 1] = selectedObjectMaterial;
            renderer.materials = materials;
        }

        isCurrentlySelected = true;
    }

    private void removeSelectionMaterial() {
        if (!isCurrentlySelected) return;

        foreach (Renderer renderer in rendererList) {
            Material[] materials = renderer.materials;
            Array.Resize(ref materials, materials.Length - 1);
            renderer.materials = materials;
        }

        isCurrentlySelected = false;
    }
}