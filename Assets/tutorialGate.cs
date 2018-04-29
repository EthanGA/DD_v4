using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialGate : MonoBehaviour {

	public bool playerEntered = false;

	void OnTriggerEnter(Collider collider) {
		
		playerEntered = true;
	}
}