using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleControls : MonoBehaviour {

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
