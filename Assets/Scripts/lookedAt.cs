using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookedAt : MonoBehaviour {
	
	public Material inactiveMaterial;
	public Material gazedAtMaterial;
	public Canvas buildingInfos;

	void Start () {
		SetGazedAt(false);
	}
	
	public void SetGazedAt(bool gazedAt) {
		if (inactiveMaterial != null && gazedAtMaterial != null) {
			GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
		} else {
			GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
		}
		
		if (buildingInfos != null) {
			buildingInfos.GetComponent<CanvasRenderer>().SetAlpha(gazedAt ? 1f : 0f);
		}    
	}
}
