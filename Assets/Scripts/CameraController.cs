using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	// Player object.
	public GameObject player;

	// Offset from player to camera.
	private Vector3 offset;

	void Start () {
		// Calculate initial offset from player, and keep it constant
		// as player moves.
		offset = transform.position - player.transform.position;
	}

	// LateUpdate() is called after all objects have moved.
	void LateUpdate () {
		// Move this camera so it maintains the original offset from player.
		transform.position = player.transform.position + offset;
	}
}
