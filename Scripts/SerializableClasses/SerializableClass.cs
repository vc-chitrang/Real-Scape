using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InteractableData : ICloneable {
    public string name;
    public int id;
    public string description;

    public object Clone() {
        InteractableData cloneData = new InteractableData {
            id = id,
            name = name,
            description = description
        };
        return cloneData;
    }
}