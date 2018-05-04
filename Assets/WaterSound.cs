using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSound : MonoBehaviour {

	public bool onWater = false;
	public AudioSource source;

	void Update() {
		if (onWater) {
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
		onWater = true;
	}

	void OnTriggerExit (Collider collider) {
		onWater = false;
	}
}