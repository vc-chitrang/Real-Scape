using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LoadAddressableUsingName))]
public class InteractableObject : MonoBehaviour {
    private LoadAddressableUsingName _addressableUtility = null;

    [SerializeField] private List<InteractableBase> _options = new List<InteractableBase>();
    private void Awake() {
        _addressableUtility = GetComponent<LoadAddressableUsingName>();
    }

    public List<InteractableBase> GetOptions() {
        return _options;
    }

    internal void DisableAllOptions() {
        _options.ForEach(o => o.gameObject.SetActive(false));
    }

    public void LoadAsset(int assetIndex) {
        DisableAllOptions();

        string assetName = _addressableUtility.GetAssetName(assetIndex);
        Debug.Log($"Asset Name: {assetName}");

        //Check if asset is already Available inside list
        if (IsAlreadyObjectAvailableInList(assetName)) {
            InteractableBase interactable = _options.Find(o => o.data.name.Contains(assetName));
            if (interactable != null) {
                interactable.gameObject.SetActive(true);
                Debug.Log($"Loaded Object Selected: {assetName}");
            }
        } else {
            //Load using addressable
            _addressableUtility.LoadAsset(assetName);
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
}

