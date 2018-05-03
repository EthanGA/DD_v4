using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBlock : MonoBehaviour {
	public Image pause;
	public GameObject tutorial1, tutorial2;

	void Update() {

		if (pause.isActiveAndEnabled == true) {
			tutorial1.SetActive(false);
	//		tutorial2.SetActive(false);
		} else {
			tutorial1.SetActive(true);
//			tutorial2.SetActive(true);
		}
	}
}
