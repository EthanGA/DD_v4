using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credits : MonoBehaviour {

	public GameObject main;

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			main.SetActive(true);
		}
	}

	public void ShowCredits() {
		main.SetActive(false);
	}
}