using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InteractableData : ICloneable {
    public string name;
    public int id;
    public string description;
    public bool defaultSelected;
    public List<MaterialsData> materialInformation = new List<MaterialsData>();

    public object Clone() {
        InteractableData cloneData = new InteractableData {
            id = id,
            name = name,
            description = description,
        };
        return cloneData;
    }
}

[Serializable]
public struct MaterialsData {
    public Material material;
    public Sprite thumbnails;
}
