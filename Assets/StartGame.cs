using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public GameObject player, key1, key2;

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject == player) {
			if (key1.GetComponent<TutorialKey>().tutorialComplete == true || key2.GetComponent<TutorialKey>().tutorialComplete == true) {
				SceneManager.LoadScene("A star");
			}
		}
	}
}
