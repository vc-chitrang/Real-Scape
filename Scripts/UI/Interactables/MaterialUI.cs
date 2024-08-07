using System;
using UnityEngine;
using UnityEngine.UI;

public class MaterialUI : MonoBehaviour {
    private int _index;
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    internal void SetIndex(int index) {
        _index = index;
    }

    internal void SetMaterialSprite(Sprite sprite) {
        _image.sprite = sprite;
    }

    internal void SetButtonClickListner(Action<int> action) {
        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() => {
            action?.Invoke(_index);
        });
    }
}
