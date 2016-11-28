/// <summary>
/// Manages loading of new scenes.
/// </summary>

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour {

	// Index of current scene.
	int activeSceneIndex;

	// Number of scenes in the game.
	int sceneCount;

	// Use this for initialization
	void Start () {
		sceneCount = SceneManager.sceneCountInBuildSettings;
	}

	// Load the next scene.
	public void LoadNextScene () {

		//UpdateSceneData();

		int newSceneIndex = GetActiveSceneIndex() + 1;
		if (newSceneIndex > sceneCount - 1) {
			newSceneIndex = 0;
		}
		SceneManager.LoadScene(newSceneIndex);
	}

	// Load the previous scene.
	public void LoadPrevScene () {

		//UpdateSceneData();

		int newSceneIndex = GetActiveSceneIndex() - 1;
		if (newSceneIndex < 0) {
			newSceneIndex = sceneCount - 1;
		}
		SceneManager.LoadScene(newSceneIndex);
	}

	// Return the integer index of the active scene.
	private int GetActiveSceneIndex() {
		Scene activeScene = SceneManager.GetActiveScene();
		activeSceneIndex = activeScene.buildIndex;

		return activeSceneIndex;
	}
}
