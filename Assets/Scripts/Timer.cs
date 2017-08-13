using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static Timer instance = null; 
	public float universalTime;
	public float timeLeft;
	public int score;

	public GameObject gm;
	public GM gmScript;

	void Awake () {
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		timeLeft = universalTime;
	}

	void Update(){
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0) {
			gmScript.GameOver ();
		}
	}

	void OnLevelWasLoaded(int level) {
		if (level == 1 && timeLeft >= 10) {
			gm = GameObject.Find ("GameMaster");
			gmScript = gm.GetComponent<GM> ();
			timeLeft = universalTime;
			universalTime -= 10;
			score++;
		} else if (level == 1 && timeLeft < 10) {
			gm = GameObject.Find ("GameMaster");
			gmScript = gm.GetComponent<GM> ();
			timeLeft = 5;
			score++;
		}

		if (level == 0) {
			universalTime = 60;
			timeLeft = universalTime;
			score = 0;
		}
	}
		
}