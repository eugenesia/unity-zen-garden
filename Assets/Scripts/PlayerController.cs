using UnityEngine;
using System.Collections;

// Control player movement.
public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;

	void Start () {
		// Get the RigidBody component so we can modify it later.
		rb = GetComponent<Rigidbody>();
	}

	// Apply forces to RigidBody every fixed frame update.
	// E.g. every physics step.
	void FixedUpdate () {

		// Detect keypresses.
		float moveHor = Input.GetAxis("Horizontal");
		float moveVert = Input.GetAxis("Vertical");

		// Convert keypresses to movement on the ground.
		Vector3 movement = new Vector3 (moveHor, 0.0f, moveVert);

		rb.AddForce(movement * speed);
	}

	// Handle collision with pickups.
	void OnTriggerEnter (Collider other) {
		// Disable the pickup that player collided with, as a sign that it's
		// been "picked up".
		other.gameObject.SetActive(false);
    }
}
