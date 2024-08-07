using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractablUI : MonoBehaviour {
    [SerializeField] private Image Image;

    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _previousButton;

    [SerializeField] private TextMeshProUGUI _information;
    public Action<int> loadAssetAction;

    internal int totalAssetCount;

    private int _selectedModelIndex = 0;
    [SerializeField] private MaterialListManagerUI _materialListManagerUI;

    private InteractableObject _interactableObject;

    public int SelectedModelIndex {
        get {
            return _selectedModelIndex;
        }
        set {
            _selectedModelIndex = value;
            RefreshNextPreviousButton();

            loadAssetAction?.Invoke(_selectedModelIndex);
        }
    }

    internal void SetInteractableObject(InteractableObject interactableObject) {
        _interactableObject = interactableObject;
    }

    internal void AssignLisners() {
        loadAssetAction += _interactableObject.LoadAsset;
        _interactableObject.onInteractableLoaded += OnInteractableLoaded;        
    }

    private void OnInteractableDownloaded(InteractableBase interactable) {
        Image.sprite = interactable.data.materialInformation[0].thumbnails;
        _information.text = $"{interactable.data.name}\n" +
                            $"{interactable.data.description}";
    }

    private void Awake() {
        _nextButton.onClick.RemoveAllListeners();
        _nextButton.onClick.AddListener(NextSelected);

        _previousButton.onClick.RemoveAllListeners();
        _previousButton.onClick.AddListener(PreviousSelected);

        _materialListManagerUI.Set(this);
    }

    public void NextSelected() {
        SelectedModelIndex++;
    }

    public void PreviousSelected() {
        SelectedModelIndex--;
    }

    private void RefreshNextPreviousButton() {
        _nextButton.gameObject.SetActive(SelectedModelIndex < totalAssetCount - 1);
        _previousButton.gameObject.SetActive(SelectedModelIndex > 0);
    }

    public void OnInteractableLoaded(InteractableBase interactableBase) {
        Image.sprite = interactableBase.data.materialInformation[0].thumbnails;
        _information.text = $"{interactableBase.data.name}\n" +
                            $"{interactableBase.data.description}";

        _materialListManagerUI.GenerateMaterialOptions(interactableBase.data.materialInformation);
    }

    internal void OnChangeMaterial(int materialIndex, Sprite materialThumbnail) {
        //3D Model Handler
        _interactableObject.OnChangeMaterial(materialIndex);

        Image.sprite = materialThumbnail;
    }    
}
