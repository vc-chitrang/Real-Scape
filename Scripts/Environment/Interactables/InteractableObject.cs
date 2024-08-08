using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LoadAddressableUsingName))]
public class InteractableObject : MonoBehaviour {
    private LoadAddressableUsingName _addressableUtility = null;

    [SerializeField] private List<InteractableBase> _options = new List<InteractableBase>();
    public Action<InteractableBase> onInteractableLoaded;
    private string selectedAssetName;

    private void Awake() {
        _addressableUtility = GetComponent<LoadAddressableUsingName>();
    }

    private void Start() {
        LoadAsset(0);
    }

    internal void DisableAllOptions() {
        _options.ForEach(o => o.gameObject.SetActive(false));
    }

    public void LoadAsset(int assetIndex) {
        DisableAllOptions();

        selectedAssetName = _addressableUtility.GetAssetName(assetIndex);

        //Check if asset is already Available inside list
        if (IsAlreadyObjectAvailableInList(selectedAssetName)) {
            InteractableBase interactable = _options.Find(o => o.data.name.Contains(selectedAssetName));
            if (interactable != null) {
                interactable.gameObject.SetActive(true);
                onInteractableLoaded?.Invoke(interactable);
            }
        } else {
            //Load using addressable
            _addressableUtility.LoadAsset(selectedAssetName);
        }
    }

    public int GetTotalAssetsCount() {
        return _addressableUtility.GetTotalAssetsCount();        
    }

    internal void AddAssetIntoList(InteractableBase interactableObject) {
        _options.Add(interactableObject);        
    }

    private bool IsAlreadyObjectAvailableInList(string assetName) {
        return _options.Any(a => a.data.name.Contains(assetName));
    }

    private InteractableBase GetInteractableByName(string name) {
        return _options.Find(o => o.data.name.Contains(name));
    }

    private InteractableBase GetSelectedInteractable() {
        return GetInteractableByName(selectedAssetName);
    }

    internal void OnChangeMaterial(int index) {
        Furniture selectedFurniture = GetSelectedInteractable() as Furniture;
        if (selectedFurniture != null) {
            selectedFurniture.SetMaterial(index);
        }
    }
}

