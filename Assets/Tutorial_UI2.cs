using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_UI2 : MonoBehaviour {

	public GameObject waterTrigger, player, player2, torch1, torch2, gate;
	bool message1, message2, lamp, firstF, secondF, lastLevel, UI1 = false;
	public Text text1, text2, text3, text4;
	float a1, a2, a3, a4 = 0;
	public Camera camera;
	public Light SunSet;
	
	void Update () {
		if (!UI1) {
			bool done = gameObject.GetComponent<Tutorial_UI>().done;
			if (done) {
				gameObject.GetComponent<Tutorial_UI>().enabled = false;
				UI1 = true;
			}
		}

		if (!secondF) {
			if (!firstF) {
				lamp = player.GetComponent<Lamp>().gotLamp;
				message2 = false;
				message1 = false;
				
				if (!lamp) {
					message2 = waterTrigger.GetComponent<WaterTrigger>().message2;
					message1 = false;
					
					if (!message2) {
						message1 = waterTrigger.GetComponent<WaterTrigger>().startMessage;
					}
				}
			}
		}	

		if (message1) {
			if (a1 < 255) {
				a1 += 0.005f;	
			}
			text1.color = new Color(255, 255, 255, a1);
		} 

		if (message2) {
			if (a1 > 0) {
				a1 -= 0.02f;
			}
			if (a2 < 255) {
				a2 += 0.005f;	
			}
			text1.color = new Color(255, 255, 255, a1);
			text2.color = new Color(255, 255, 255, a2);
		}

		if (lamp && !firstF) {
			a1 = 0;

			if (a2 > 0) {
				a2 -= 0.02f;
			}
			if (a3 < 255) {
				a3 += 0.005f;	
			}
			text1.color = new Color(255, 255, 255, a1);
			text2.color = new Color(255, 255, 255, a2);
			text3.color = new Color(255, 255, 255, a3);

			if (Input.GetKeyDown(KeyCode.F)) {
				firstF = true;
				lamp = false;
			}
		} 
		
		if (firstF) {
			a1 = 0;
			a2 = 0;

			if (a3 > 0) {
				a3 -= 0.02f;
			}
			if (a4 < 255) {
				a4 += 0.01f;	
			}
			text1.color = new Color(255, 255, 255, a1);
			text2.color = new Color(255, 255, 255, a2);
			text3.color = new Color(255, 255, 255, a3);
			text4.color = new Color(255, 255, 255, a4);

			if (Input.GetKeyDown(KeyCode.F)) {
				secondF = true;
			}

		}

		if (secondF) {
			if (a4 < 255) {
				a4 += 0.01f;	
			}

			text1.color = new Color(255, 255, 255, 0);
			text2.color = new Color(255, 255, 255, 0);
			text3.color = new Color(255, 255, 255, 0);
			text4.color = new Color(255, 255, 255, a4);

			torch1.SetActive(true);
			torch2.SetActive(true);
			lastLevel = gate.GetComponent<nextLevel>().lastLevel;
		}

		if (lastLevel) {
			player.SetActive(false);
			camera.GetComponent<FollowPlayer>().player = player2;
			player2.SetActive(true);
			SunSet.GetComponent<SunSet_Color>().start = true;
			gate.SetActive(false);
			text1.enabled = false;
			text2.enabled = false;
			text3.enabled = false;
			text4.enabled = false;
		}
	}
}