using System;
using UnityEngine;
using UnityEngine.UI;

public class MaterialUI : MonoBehaviour {
    private int _index;
    [SerializeField] private Image _image;
    [SerializeField] private Image _highlightImage;

    [SerializeField] internal Button _button;
    private MaterialListManagerUI _materialListManagerUI;

    private void Start() {
        SetHighlighter(false);
    }

    internal void Init(MaterialListManagerUI materialListManagerUI) {
        _materialListManagerUI = materialListManagerUI;
    }

    internal void SetIndex(int index) {
        _index = index;
    }

    internal void SetMaterialSprite(Sprite sprite) {
        _image.sprite = sprite;
    }

    internal void SetButtonClickListner(Action<int,Sprite> action) {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => {
            _materialListManagerUI.DeSelectAllMaterialUI();
            SetHighlighter(true);
            action?.Invoke(_index, _image.sprite);
        });
    }

    internal void SetHighlighter(bool isHighlighted) {
        _highlightImage.gameObject.SetActive(isHighlighted);
    }
}
