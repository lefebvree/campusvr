using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRMovement : MonoBehaviour {
	
	// Movement to be use
	//   0 : Walking by looking down
	//   1 : Flying by touching the screen
	public int movementType = 0;
	//max movement type
	private int maxMovementType = 2;
	
	// CharacterController script
	private CharacterController controller;

	// VR Main Camera
	public Transform vrHead;

	// How fast to move
	public float speed = 15.0f;

	// Should I move forward or not
	public bool moveForward;
	
	// Angle at witch walk/stop will be triggered (X value of main camera)
	public float toggleAngle = 25.0f;
	
	public Dropdown teleportOption;

	
	// Use this for initialization
	void Start() {
		// Find the CharacterController
		controller = GetComponent<CharacterController>();
		// Get the VR Head Camera
		//vrHead = Camera.main.transform;
	}
	
	public void ChangeMovementType() {
		movementType = movementType + 1;
		if(movementType == maxMovementType) {
			movementType = 0;
		}
	}
	public void Teleport() {
		int option = teleportOption.value;
		print(option);
		
		switch(option) {
			case 0:
				transform.position = new Vector3(543, 0, 102);
				break;
			case 1:
				transform.position = new Vector3(407, 0, 464);
				break;
			case 2:
				transform.position = new Vector3(572, 0, 330);
				break;
		}
	}
	
	// Update is called once per frame
	void Update() {
		switch (movementType) {
			
			case 0:
			
				// Move if angle is respected
				moveForward = (vrHead.eulerAngles.x >= toggleAngle && vrHead.eulerAngles.x < 90.0f);

				// Check to see if I should move
				if (moveForward) {
					// Find the forward direction
					Vector3 forward = vrHead.TransformDirection(Vector3.forward);
					// Tell CharacterController to move forward
					controller.SimpleMove(forward * speed);
				}
				
				break;

			case 1:

				if(Input.GetButtonDown("Fire1") || Input.GetButtonUp("Fire1")) {
					// Toggle movement
					moveForward = !moveForward;
				}
				
				if (moveForward) {
					// Find the forward direction
					Vector3 forward = vrHead.TransformDirection(Vector3.forward);
					// Tell CharacterController to move forward
					controller.Move(forward * speed * Time.deltaTime);
				}
			
				break;
		}
		
	}
}

