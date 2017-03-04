using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTouchWalk : MonoBehaviour {

	// VR Main Camera
	public Transform vrCamera;

	// How fast to move
	public float speed = 15.0f;

	// CharacterController script
	private CharacterController cc;

	// Use this for initialization
	void Start() {
		// Find the CharacterController
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update() {
		foreach(Touch touch in Input.touches) {
			// Find the forward direction
			Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
			// Tell CharacterController to move forward
			cc.Move(forward * speed);
		}
	}
}
