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
    }

    internal async void LoadAsset(string assetName, Transform _parent = null) {
        if (_parent == null) {
            _parent = transform;
        }
        await AddressablesLoader.InstantiatePrefabAsync(assetName, _parent, OnAssetLoaded, OnPrefabLoadingProgress);
    }

    private async void InstantiatePrefabs() {
        foreach (var assetName in _assetNames) {
            await AddressablesLoader.InstantiatePrefabAsync(assetName, _parent, OnAssetLoaded, OnPrefabLoadingProgress);
        }
    }

    private void OnAssetLoaded(GameObject obj) {
        if (obj != null) {
            obj.name = obj.name.Replace("(Clone)", ""); //Remove (Clone) Text from object name
            InteractableBase interactableObject = obj.GetComponent<InteractableBase>();
            if (interactableObject != null) {
                _interactableObject.AddAssetIntoList(interactableObject);

                _interactableObject.DisableAllOptions();
                interactableObject.gameObject.SetActive(true);

                _interactableObject.onInteractableLoaded?.Invoke(interactableObject);

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
