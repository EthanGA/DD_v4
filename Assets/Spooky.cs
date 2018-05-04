using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spooky : MonoBehaviour {

	public GameObject player, gwyllgi, SunSet, key1, key2;
	public Light light;
	bool once, msg1, msg2, msg3, msg4, msg5, keys = false;
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
				if (a1 <= 1) {
					a1 += 0.005f;
					t1.color = new Color(255, 255, 255, a1);
				} else {
					Debug.Log("reached else");
					msg2 = true;
					msg1 = false;
				}
			}

			if (msg2) {
				if (a1 >= 0) {
					a1 -= 0.05f;
					t1.color = new Color(255, 255, 255, a1);
					
				}
				if (a2 <= 1) {
					a2 += 0.005f;
					t2.color = new Color(255, 255, 255, a2);
				} else {
					msg3 = true;
					msg2 = false;
				}
			}

			if (msg3) {
				if (a2 >= 0) {
					a2 -= 0.05f;
					t2.color = new Color(255, 255, 255, a2);
					
				}
				if (a3 <= 1) {
					a3 += 0.005f;
					t3.color = new Color(255, 255, 255, a3);
				} else {
					msg4 = true;
					msg3 = false;
				}
			}

			if (msg4) {
				
				if (a3 >= 0) {
					a3 -= 0.05f;
					t3.color = new Color(255, 255, 255, a3);
					
				}
				if (a4 <= 1) {
					a4 += 0.005f;
					t4.color = new Color(255, 255, 255, a4);
				} else {
					msg5 = true;
					msg4 = false;
				}
			}

			if (msg5) {
				if (a4 >= 0) {
					a4 -= 0.05f;
					t4.color = new Color(255, 255, 255, a4);	
				}

				if (!keys) {
					PlaceKeys();
				}
				
			
			}
		}
	}

	void PlaceKeys() {
		if (Physics.CheckSphere(key1.transform.position, 5f, 0)) {
			key2.SetActive(true);
		} else {
			key1.SetActive(true);
		}
	}
}
