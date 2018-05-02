using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialBlock : MonoBehaviour {
	public Image pause;

	void Update() {

		if (pause.enabled == true) {
			gameObject.SetActive(false);
		} else {
			gameObject.SetActive(true);
		}
	}
}
