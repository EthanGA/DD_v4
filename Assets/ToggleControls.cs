using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleControls : MonoBehaviour {

	public float brightness;
	public Slider slider;

	public void BrightnessChange() {
		brightness = slider.value;
	}

	public void MainMenu() {
		SceneManager.LoadScene("MainMenu");
	}

	public void Toggle() {
		Debug.Log("toggle pressed");
		if (MovementType.tank) {
			MovementType.tank = false;
		}

		if (!MovementType.tank) {
			MovementType.tank = true;
		}
	}
}
