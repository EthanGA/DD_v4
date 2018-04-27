using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restart : MonoBehaviour {

	

	void Restart () {
		BoolStorage.firstTime = true;
		BoolStorage.gameCount = 0;
		Scene loadedLevel = SceneManager.GetActiveScene();
     	SceneManager.LoadScene (loadedLevel.buildIndex);
	}
}
