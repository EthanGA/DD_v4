using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour {

	public bool startMessage = false;
	public bool message2 = false;
	public AudioSource source;

	void Update() {
		if (startMessage) {
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) {
				if (source.volume < 0.1f) {
					source.volume += 0.01f;
				}
				
			} else {
				if (source.volume > 0f) {
					source.volume -= 0.025f;
				}
			}
		} else {
			source.volume = 0;
		}
	}

	void OnTriggerEnter (Collider collider) {
		startMessage = true;
	}

	void OnTriggerExit (Collider collider) {
		message2 = true;
		startMessage = false;
	}
}
