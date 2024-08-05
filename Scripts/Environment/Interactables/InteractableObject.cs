using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractableObject : MonoBehaviour {
    [SerializeField] private List<InteractableBase> _options = new List<InteractableBase>();
    private void Awake() {
        _options.Clear();
        _options = GetComponentsInChildren<InteractableBase>(true).ToList();
        for (int i = 0; i < _options.Count; i++)
        {
            InteractableBase option = _options[i];
            option.gameObject.SetActive(i == 0);
            option.data.id = i;
            option.Init();
        }        
    }

    public List<InteractableBase> GetOptions() {
        return _options;
    }

    private void DisableAllOptions() {
        _options.ForEach(o => o.gameObject.SetActive(false));
    }

    public void onSelectionUpdate(int selectedIndex) {
        DisableAllOptions();
        _options[selectedIndex].gameObject.SetActive(true);
    }
}

