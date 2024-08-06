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
    public int SelectedModelIndex {
        get {
            return _selectedModelIndex;
        }
        set {
            _selectedModelIndex = value;
            RefreshNextPreviousButton();
            UpdateUI();

            loadAssetAction?.Invoke(_selectedModelIndex);
        }
    }

    private void Awake() {
        _nextButton.onClick.RemoveAllListeners();
        _nextButton.onClick.AddListener(NextSelected);

        _previousButton.onClick.RemoveAllListeners();
        _previousButton.onClick.AddListener(PreviousSelected);
    }

    public void UpdateUI() {
        if (totalAssetCount == 0) {
            return;
        }
        //TODO: Get All Available Options --->>

        //InteractableBase selectedInteractable = options[SelectedModelIndex];
        //if (selectedInteractable != null) {
        //    name = selectedInteractable.data.name;

        //    Image.sprite = selectedInteractable.data.sprite;
        //    _information.text = $"{selectedInteractable.data.name}\n" +
        //                        $"{selectedInteractable.data.description}";
        //}
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
}
