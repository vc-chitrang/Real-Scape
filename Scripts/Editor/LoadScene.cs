using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;

public class LoadScene {
    [MenuItem("Load_Scene/MovementController")]
    static void MovementController() {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
            EditorSceneManager.OpenScene("Assets/Games/Real-Scape/Scenes/MovementController.unity");
        }
    }

    [MenuItem("Load_Scene/InteriorScene")]
    static void InteriorScene() {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) {
            EditorSceneManager.OpenScene("Assets/Games/Real-Scape/Scenes/InteriorScene.unity");
        }
    }
}//LoadScene class end
