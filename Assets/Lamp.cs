using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {
	public GameObject playerLight;
	public Light pointLight;
	public bool gotLamp = false;

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "Lamp") {
			gotLamp = true;
			collider.gameObject.SetActive(false);
			playerLight.SetActive(true);
			pointLight.enabled = true;
	
		}
	}
}