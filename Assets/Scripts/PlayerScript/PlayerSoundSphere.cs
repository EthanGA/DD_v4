using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundSphere : MonoBehaviour {

	public AudioClip grassNormal;
	public AudioClip grassSlow;
	public AudioClip grassFast;
	public AudioClip waterNormal;
	public AudioClip waterSlow;
	public AudioClip waterFast;

	public AudioSource movement;

	bool playingWater = false;
	bool playingGrass = false;

	void Update() {
		
		RaycastHit hit;
		Vector3 origin = gameObject.transform.position;
		
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
			if (Physics.Raycast(origin, Vector3.down, out hit)) {
				if (hit.collider.tag == "Grass") {
					if (!playingGrass && Input.GetKey(KeyCode.LeftShift)) {
						movement.clip = grassFast;
						movement.volume = 1;
						playingGrass = true;
						playingWater = false;
						
					} else if (!playingGrass && Input.GetKey(KeyCode.LeftControl)) {
						movement.clip = grassSlow;
						movement.volume = 1;
						playingGrass = true;
						playingWater = false;
						
					} else {
						movement.clip = grassNormal;
						movement.volume = 1;
						playingGrass = true;
						playingWater = false;
					}
				}

				if (hit.collider.tag == "Water") {
					if (!playingWater && Input.GetKey(KeyCode.LeftShift)) {
						movement.clip = waterFast;
						movement.volume = 1;
						playingWater = true;
						playingGrass = false;
			
					} else if (!playingWater && Input.GetKey(KeyCode.LeftControl)) {
						movement.clip = waterSlow;
						movement.volume = 1;
						playingWater = true;
						playingGrass = false;
		
					} else {
						movement.clip = waterNormal;
						movement.volume = 1;
						playingWater = true;
						playingGrass = false;
					}
				}
			}
		} else {
			movement.volume = 0f;
			playingGrass = false;
			playingWater = true;
		}
	}
}
