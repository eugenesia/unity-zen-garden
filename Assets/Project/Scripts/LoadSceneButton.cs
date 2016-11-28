/// <summary>
/// Behaviors for a button that will load the prev/next scene.
/// This sets a timed gaze function that clicks the button after the user
/// gazes for a particular duration.
/// Ref: https://www.youtube.com/watch?v=M6sL0ffosds
/// </summary>
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadSceneButton : MonoBehaviour {

	// GameObject in charge of scene-level admin.
	private GameObject sceneController;

	// Whether the Google Cardboard user is gazing at this button.
	private bool isLookedAt = false;

	// How long the user can gaze at this before the button is clicked.
	public float timerDuration = 3f;

	// Count time the player has been gazing at the button.
	private float lookTimer = 0f;

	// Gaze timer indicator.
	private GameObject gazeTimer;


	// Use this for initialization
	void Start () {
		sceneController = GameObject.Find("SceneController");

		gazeTimer = GameObject.Find("GazeTimer");
	}
	
	// Update is called once per frame
	void Update () {

		// While player is looking at this button.
		if (isLookedAt) {

			// Increment the gaze timer.
			lookTimer += Time.deltaTime;

			// Set cutoff value on gaze timer indicator so it shows a part circle
			// indicating time left.
			gazeTimer.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f - lookTimer / timerDuration);

			// Gaze time exceeded limit - button is considered clicked.
			if (lookTimer > timerDuration) {
				lookTimer = 0f;

				Debug.Log("Button selected!");
				GetComponent<Button>().onClick.Invoke();
			}
		}

		// Not gazing at this anymore, reset everything.
		else {
			lookTimer = 0f;
			gazeTimer.GetComponent<Renderer>().material.SetFloat("_Cutoff", 1f);
		}
	}

	// Record whether Google Cardboard user is gazing at the button.
	// gazedAt: Set it to the value passed from event trigger.
	public void SetGazedAt(bool gazedAt) {
		isLookedAt = gazedAt;
	}

	// Call the SceneController to load the next scene in build settings.
	public void LoadNextScene() {
		sceneController.GetComponent<SceneController>().LoadNextScene();
	}

	// Call the SceneController to load the previous scene in build settings.
	public void LoadPrevScene() {
		sceneController.GetComponent<SceneController>().LoadPrevScene();
	}

}
