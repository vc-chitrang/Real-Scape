using UnityEngine;

public class InteractableBase : MonoBehaviour {
    public InteractableData data;

    public virtual void Init() {
        gameObject.SetActive(data.defaultSelected);
    }
}
