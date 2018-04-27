using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	
	public void NextScene() {
		SceneManager.LoadScene("A star");
	}
}