using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InteractableData : ICloneable {
    public string name;
    public int id;
    public Sprite sprite;
    public string description;
    public bool defaultSelected;

    public object Clone() {
        InteractableData cloneData = new InteractableData {
            id = id,
            name = name,
            description = description
        };
        return cloneData;
    }
}