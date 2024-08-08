using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class DrawMeshGizmo : MonoBehaviour {
    public Color gizmoColor = Color.black; // Color of the gizmo
    public bool drawWireframe = true; // Option to draw wireframe

    private Mesh mesh;

    void OnDrawGizmos() {
        // Disable gizmos when the game is in play mode
        if (Application.isPlaying)
            return;

        Gizmos.color = gizmoColor;

        // Get the mesh from the MeshFilter component
        mesh = GetComponent<MeshFilter>().sharedMesh;

        if (mesh != null) {
            if (drawWireframe) {
                // Draw the mesh wireframe
                Gizmos.DrawWireMesh(mesh, transform.position, transform.rotation, transform.localScale);
            } else {
                // Draw the solid mesh
                Gizmos.DrawMesh(mesh, transform.position, transform.rotation, transform.localScale);
            }
        }
    }
}
