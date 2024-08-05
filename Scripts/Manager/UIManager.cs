using StarterAssets;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    [SerializeField] StarterAssetsInputs _starterAssetsInputs;
    [SerializeField] private GameObject _controllerPanel;
    [SerializeField] private Toggle _controlToggle;
    [SerializeField] private Text _controlToggleText;

    private void Start() {
        _controlToggle.onValueChanged.RemoveAllListeners();
        _controlToggleText.text = _controlToggle.isOn ? "Disable Android Control" : "Enable Android Control";
        _controlToggle.onValueChanged.AddListener((isEnable) => {            
            _starterAssetsInputs.cursorLocked = !isEnable;
            _starterAssetsInputs.cursorInputForLook = !isEnable;
            _controllerPanel.SetActive(isEnable);
            _controlToggleText.text = isEnable ? "Disable Android Control" : "Enable Android Control";
        });
    }
}
