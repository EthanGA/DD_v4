using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credits : MonoBehaviour {

	public GameObject main;
	public GameObject playOptions;

	void Awake() {
		gameObject.GetComponent<Text>().enabled = false;
	}
	
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			main.SetActive(true);
			playOptions.SetActive(false);
			gameObject.GetComponent<Text>().enabled = false;
		}
	}

	public void ShowCredits() {
		main.SetActive(false);
		playOptions.SetActive(false);
		gameObject.GetComponent<Text>().enabled = true;
	}

	public void ShowPlayOptions() {
		gameObject.GetComponent<Text>().enabled = true;
		main.SetActive(false);
		playOptions.SetActive(true);
	}
}