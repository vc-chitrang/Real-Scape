using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Furniture : InteractableBase {
    private MeshRenderer _meshRenderer;
    private void Awake() {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    internal void SetMaterial(int index) {
        Debug.Log($"Material Changed: {index} :: on {data.name}");
        Material selectedMaterial = data.materialInformation[index % data.materialInformation.Count].material;
        _meshRenderer.material = selectedMaterial;
    }
}
