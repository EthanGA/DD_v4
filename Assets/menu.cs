using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
	
	public void NextScene() {
		SceneManager.LoadScene("A star");
	}

	public void Tank() {
		MovementType.tank = true;
	}

	public void Traditional() {
		MovementType.tank = false;
	}
}