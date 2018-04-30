using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCanvas : MonoBehaviour {

	bool paused;
	public GameObject player, canvas;

	void Start () {
		paused = player.GetComponent<Movement>().paused;
	}
	

	void Update () {
		if (paused) {
			canvas.SetActive(false);
		} else {
			canvas.SetActive(true);
		}
	}
}
