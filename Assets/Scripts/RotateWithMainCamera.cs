///
/// Rotate the object horizontally, with the main camera.
///

using UnityEngine;
using System.Collections;

public class RotateWithMainCamera : MonoBehaviour {

	private GameObject mainCam;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		// Get horizontal component of camera's orientation, by projecting
		// the vector onto the horizontal plane.
		Vector3 camForwardHoriz = Vector3.ProjectOnPlane(
			mainCam.transform.forward, Vector3.up);

		// Rotate this object horizontally, to align with cam. 
		transform.rotation = Quaternion.LookRotation(camForwardHoriz);
	}
}
