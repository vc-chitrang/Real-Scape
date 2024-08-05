using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Furniture : InteractableBase {
    protected override void Init() {
        base.Init();
        List<Transform> furnitureList = GetComponentsInChildren<Transform>(true).Where(t => t.transform != this.transform).ToList();
        for (int i = 0; i < furnitureList.Count; i++) {
            Transform model = furnitureList[i];

            model.gameObject.SetActive(i == 0);

            InteractableData furniture = new InteractableData();
            furniture.id = i;
            furniture.name = model.gameObject.name;
            furniture.description = $"This is {model.gameObject.name} description";

            AddInteractable(furniture);

            Debug.Log(furniture.description);
        }
    }
}
