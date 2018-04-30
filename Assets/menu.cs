using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
	
	public static bool tutorial;

	public void tutorialOn() {
		tutorial = true;
	}

	public void tutorialOff() {
		tutorial = false;
	}

	public void NextScene() {
		if (tutorial) {
			SceneManager.LoadScene("Intro2");
		}
		if (!tutorial) {
			SceneManager.LoadScene("A Star");
		}
	}

	public void Tank() {
		MovementType.tank = true;
	}

	public void Traditional() {
		MovementType.tank = false;
	}
}