using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	
	public static AudioManager instance = null; 
	public static bool stopper = false;
	public AudioSource bgAudio;

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
	}

	void Update(){
		if (stopper) {
			bgAudio.Stop ();
		}
	}

	void OnLevelWasLoaded(int level){
		if (level == 0) 
			bgAudio.Stop ();

		if (level == 2)
			bgAudio.Play ();
	}
}
