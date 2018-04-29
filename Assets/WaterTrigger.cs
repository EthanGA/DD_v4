using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour {

	public bool startMessage = false;
	public bool message2 = false;

	void OnTriggerEnter (Collider collider) {
		startMessage = true;
	}

	void OnTriggerExit (Collider collider) {
		message2 = true;
		startMessage = false;
	}
}
