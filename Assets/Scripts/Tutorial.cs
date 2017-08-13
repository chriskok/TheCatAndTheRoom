using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
	public int level;
	public GameObject cat;
	private Animator anim;
	public float timeNeeded = 1;

	void Start(){
		if (cat != null) {
			anim = cat.GetComponent<Animator> ();
		}
	}

	public void Continue(){
		if (cat != null) {
			anim.SetTrigger ("Recite");
		}
		Invoke ("NextScene", timeNeeded);
	}

	void NextScene(){
		SceneManager.LoadScene (level);
	}

	public void SkipTutorial(){
		SceneManager.LoadScene ("Main");
	}
}
