using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialKey : MonoBehaviour {

	public GameObject player, torch1, torch2;
	public bool tutorialComplete = false;
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == player) {
			torch1.SetActive(true);
			torch2.SetActive(true);
			tutorialComplete = true;
			gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
		}
	}
}
