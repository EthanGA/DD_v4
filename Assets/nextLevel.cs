using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour {

	public GameObject player;
	public GameObject player2;
	public Camera camera;
	public Light sun;

	void OnCollisionEnter (Collision collision) {
		if (collision.collider.gameObject.tag == "Player") {
			if (player.GetComponent<Lamp>().gotLamp) {
				//player.transform.position = new Vector3(0f, 0.54f, 20f);
				player2.SetActive(true);
				camera.GetComponent<FollowPlayer>().player = player2;
				player.SetActive(false);
				sun.transform.position = new Vector3 (-14.62f, 33.27f, 25);
			}
		}
	}
}
