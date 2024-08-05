using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour, ISelectNextPrevious {
    public List<InteractableData> interactables = new List<InteractableData>();
    private int _selectedModelIndex = 0;
    private int selectedModelIndex {
        get {
            return _selectedModelIndex;
        }
        set {
            _selectedModelIndex = value;            
        }
    }
    private void Start() {
        Init();
    }

    protected virtual void Init() {
        interactables.Clear();
    }

    protected void AddInteractable(InteractableData interactable) {
        interactables.Add(interactable);
    }

    public void NextSelected() {
        selectedModelIndex++;
    }

    public void PreviousSelected() {
        selectedModelIndex--;
    }
}
