using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBlock : MonoBehaviour {
	public Image pause;
	public GameObject tutorial;

	void Update() {

		if (pause.isActiveAndEnabled == true) {
			tutorial.SetActive(false);
		} else {
			tutorial.SetActive(true);
		}
	}
}
