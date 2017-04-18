using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleportTo : MonoBehaviour {
	
	public Dropdown teleportOption;

	public void Teleport() {
		int option = teleportOption.value;
		
		switch(option) {
			case 1:
				// Entrance
				transform.position = new Vector3(543, 0, 102);
				break;
			case 2:
				// BU
				transform.position = new Vector3(572, 0, 330);
				break;
			case 3:
				// B.5
				transform.position = new Vector3(407, 0, 464);
				break;
		}
		
		// Reset selected value
		teleportOption.value = 0;
	}
}
