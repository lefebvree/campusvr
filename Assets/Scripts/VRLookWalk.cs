using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour {

	// VR Main Camera
	public Transform vrCamera;

	// ANgle at witch walk/stop will be triggered (X value of main camera)
	public float toggleAngle = 25.0f;
	// How fast to move
	public float speed = 15.0f;

	// Should I move forward or not
	public bool moveForward;

	// CharacterController script
	private CharacterController cc;

	// Use this for initialization
	void Start() {
		// Find the CharacterController
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update() {
		if(vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f) {
			// Move forward
			moveForward = true;
		} else {
			// Stop moving
			moveForward = false;
		}

		// Check to see if I should move
		if (moveForward) {
			// Find the forward direction
			Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
			// Tell CharacterController to move forward
			cc.SimpleMove(forward * speed);
		}
	}
}
