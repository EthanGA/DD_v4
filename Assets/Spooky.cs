using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spooky : MonoBehaviour {

	public GameObject player, gwyllgi, SunSet;
	public Light light;
	bool once, msg1, msg2, msg3, msg4, msg5 = false;
	public Text t1, t2, t3, t4;
	float a1, a2, a3, a4, timer = 0;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == player) {
			if (!once) {
				gwyllgi.SetActive(true);
				gameObject.GetComponent<BoxCollider>().enabled = false;
				once = true;
				msg1 = true;
			}
		}
	}

	void FixedUpdate() {
		if (once) {
			if (msg1) {
				if (a1 < 255) {
					a1 += 0.01f;
					t1.color = new Color(255, 255, 255, a1);
				} else {
					msg2 = true;
					msg1 = false;
				}
			}

			if (msg2) {
				if (a1 > 0) {
					a1 -= 0.1f;
					t1.color = new Color(255, 255, 255, a1);
				}
				if (a2 < 255) {
					a2 += 0.01f;
					t2.color = new Color(255, 255, 255, a2);
				} else {
					msg3 = true;
					msg2 = false;
				}
			}

			if (msg3) {

			}

			if (msg4) {

			}

			if (msg5) {

			}
		}
	}
}
