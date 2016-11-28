/// <summary>
/// Pointer to the Scene Controller gameobject. This is so that the button
/// in this prefab can retain a pointer to the SceneController, which is not
/// in this prefab.
/// See http://stackoverflow.com/questions/35681134/ui-prefabs-buttons-does-not-retain-onclick-settings
/// </summary>

using UnityEngine;
using System.Collections;

public class SceneControllerPointer : MonoBehaviour {

	private GameObject sceneController;

	// Use this for initialization
	void Start () {
		sceneController = GameObject.Find("SceneController");		
	}

	public void LoadNextScene () {
		sceneController.GetComponent<SceneController>().LoadNextScene();
	}

	public void LoadPrevScene () {
		sceneController.GetComponent<SceneController>().LoadPrevScene();
	}
}
