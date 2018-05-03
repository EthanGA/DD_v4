using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSet_Color : MonoBehaviour {

	float red = 0.831f;
	float x = 0.7f;
	public bool start = false;
	
	void Update () {
		if (start) {
			GetComponent<Light>().color = new Color(0.839f, red, 0.094f, 1);
		 	transform.rotation = new Quaternion(x, 0.1f, 0.4f, 0.6f);
		}
	}

	void FixedUpdate() {
		if (start) {
			if (red > 0.01f) {
				red = red - 0.01f * Time.deltaTime;
			}

			if (x > 0.1) {
				x -= 0.001f;
			}

			if (red <= 0.01f && x <= 0.1) {
				GetComponent<Light>().intensity -= 0.001f;
				if (GetComponent<Light>().intensity == 0) {
					gameObject.SetActive(false);
				}
			}
		}	
	}
}