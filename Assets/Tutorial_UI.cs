using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_UI : MonoBehaviour {

	public GameObject player, player2, gate;
	public Text txt1, txt2, txt3, txt4;
	bool start, trans1, trans2, trans3, end = false;
	float a1, a2, a3, a4 = 0;
	float a5;
	public Material hide_Mat;
	MeshRenderer rend;
	public Camera camera;
	public Light SunSet;
	bool w, a, s, d, q, e, wallGone, playerEntered = false;
	public bool done = false;

	void Awake() {
		start = true;
	}

	void Update() {

		playerEntered = gate.GetComponentInChildren<tutorialGate>().playerEntered;

		if (start && Input.GetKeyDown("w")) {
				w = true;
		}
		if (start && Input.GetKeyDown("a")) {
				a = true;
		}
		if (start && Input.GetKeyDown("s")) {
				s = true;
		}
		if (start && Input.GetKeyDown("d")) {
				d = true;
		}
		if (trans1 && Input.GetKeyDown("q")) {
				q = true;
		} 
		if (trans1 && Input.GetKeyDown("e")) {
				e = true;
		}
	}

	void FixedUpdate() {
		if (start) {
			if (a1 < 255) {
				a1 += 0.005f;			
			}
			txt1.color = new Color(255, 255, 255, a1);
			if (w && a && s && d) {
				start = false;
				trans1 = true;
			}
		}

		if (trans1) {
			if (a1 > 0) {
				a1 -= 0.02f;
			}
			if (a2 < 255) {
				a2 += 0.005f;	
			}
			txt1.color = new Color(255, 255, 255, a1);
			txt2.color = new Color(255, 255, 255, a2);
			if (q && e) {
				trans1 = false;
				trans2 = true;
				txt1.color = new Color(255, 255, 255, 0);
			}
		}

		if (trans2) {
			if (a2 > 0) {
				a2 -= 0.02f;
			}
			if (a3 < 255) {
				a3 += 0.005f;	
			}
			txt2.color = new Color(255, 255, 255, a2);
			txt3.color = new Color(255, 255, 255, a3);
			if (Input.GetKey(KeyCode.LeftControl)) {
				if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")) {
					trans2 = false;
					trans3 = true;
					txt2.color = new Color(255, 255, 255, 0);
				}
			}
		}

		if (trans3) {
			if (a3 > 0) {
				a3 -= 0.02f;
			}
			if (a4 < 255) {
				a4 += 0.005f;	
			}
			txt3.color = new Color(255, 255, 255, a3);
			txt4.color = new Color(255, 255, 255, a4);
			if (Input.GetKey(KeyCode.LeftShift)) {
				if (Input.GetKeyDown("w") || Input.GetKeyDown("a") || Input.GetKeyDown("s") || Input.GetKeyDown("d")) {
					txt3.color = new Color(255, 255, 255, 0);
					trans3 = false;
					end = true;
				}
			}
		}

		if (end) {
			
			if (a4 > 0) {
				a4 -= 0.02f;
				txt4.color = new Color(255, 255, 255, a4);
			} 

			if (!playerEntered) {
				gate.SetActive(true);
			}
			
			if (playerEntered) {
				player.SetActive(false);
				camera.GetComponent<FollowPlayer>().player = player2;
				player2.SetActive(true);
				SunSet.GetComponent<SunSet_Color>().start = true;
				gate.SetActive(false);
				done = true;
			}	
		}	
	}
}