using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableListManagerUI : MonoBehaviour {
    [SerializeField] private List<InteractableObject> _interactableObjectsList = new List<InteractableObject>();

    [SerializeField]
    private InteractablUI _interactableUIPrefab;
    [SerializeField]
    private RectTransform _content;

    private void Start() {
        FindAllInteractables();
        InitUI();
    }

    private void FindAllInteractables() {
        _interactableObjectsList.Clear();
        _interactableObjectsList = FindObjectsOfType<InteractableObject>().ToList();
    }

    private void InitUI() {
        for (int i = 0; i < _interactableObjectsList.Count; i++) {
            InteractablUI _interactableUI = Instantiate(_interactableUIPrefab, _content);
            _interactableUI.totalAssetCount = _interactableObjectsList[i].GetTotalAssetsCount();
            _interactableUI.SelectedModelIndex = 0;

            InteractableObject interactableObject = _interactableObjectsList[i];
            _interactableUI.SetInteractableObject(interactableObject);
            _interactableUI.AssignLisners();
        }
    }
}
