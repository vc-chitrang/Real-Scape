using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoadAddressableUsingName : MonoBehaviour {
    [SerializeField] private List<string> _assetNames;
    private Transform _parent;
    private InteractableObject _interactableObject;

    private void Awake() {
        _interactableObject = GetComponent<InteractableObject>();
    }

    private void Start() {
        _parent = transform;
        LoadAsset(_assetNames.First());
    }

    internal async void LoadAsset(string assetName) {
        await AddressablesLoader.InstantiatePrefabAsync(assetName, _parent, OnAssetLoaded, OnPrefabLoadingProgress);
    }

    private async void InstantiatePrefabs() {
        foreach (var assetName in _assetNames) {
            await AddressablesLoader.InstantiatePrefabAsync(assetName, _parent, OnAssetLoaded, OnPrefabLoadingProgress);
        }
    }

    private void OnAssetLoaded(GameObject obj) {
        if (obj != null) {
            InteractableBase interactableObject = obj.GetComponent<InteractableBase>();
            if (interactableObject != null) {
                _interactableObject.AddAssetIntoList(interactableObject);

                _interactableObject.DisableAllOptions();
                interactableObject.gameObject.SetActive(true);

                Debug.Log($"Asset {obj.name} loaded successfully.");
            }
        }
    }

    private void OnPrefabLoadingProgress(float progress) {
        Debug.Log($"Loading progress: {progress * 100}%");
    }

    internal int GetTotalAssetsCount() {
        return _assetNames.Count;
    }

    internal string GetAssetName(int index) {
        return _assetNames[index];
    }
}
