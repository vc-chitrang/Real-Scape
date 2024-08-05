using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour { 
    public InteractableData data;

    public virtual void Init() {
        gameObject.SetActive(data.defaultSelected);
    }
}
