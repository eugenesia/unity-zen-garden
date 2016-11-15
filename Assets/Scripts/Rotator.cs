using UnityEngine;
using System.Collections;

// Rotates an object.
public class Rotator : MonoBehaviour {

	// Update is called once per frame
	// Not doing any physics-related changes, so can use Update().
	void Update () {
		//Vector3 rotation = new Vector3
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
