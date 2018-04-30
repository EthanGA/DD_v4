using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_UI2 : MonoBehaviour {

	public GameObject waterTrigger, player, torch1, torch2;
	bool message1, message2, lamp, firstF, secondF = false;
	public Text text1, text2, text3, text4;
	float a1, a2, a3, a4 = 0;
	
	void Update () {
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
				a4 += 0.005f;	
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
			if (a4 > 0) {
				a4 -= 0.02f;
			}
			text1.color = new Color(255, 255, 255, 0);
			text2.color = new Color(255, 255, 255, 0);
			text3.color = new Color(255, 255, 255, 0);
			text4.color = new Color(255, 255, 255, a4);

			torch1.SetActive(true);
			torch2.SetActive(true);
		}
	}
}