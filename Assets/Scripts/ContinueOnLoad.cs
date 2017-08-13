using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContinueOnLoad : MonoBehaviour {

	public float timeNeeded;

	void Start () {
		Invoke ("Load", timeNeeded);
	}

	void Load(){
		SceneManager.LoadScene ("Main");
	}
}
