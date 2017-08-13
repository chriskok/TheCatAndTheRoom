using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGM : MonoBehaviour {

	public Image gameStart;

	public void LoadTutorial(){
		SceneManager.LoadScene ("Tutorial");
	}

	public void LoadCredits(){
		SceneManager.LoadScene ("Credits");
	}

	public void EnterAnim(){
		gameStart.gameObject.SetActive (true);
		Animator GSanim = gameStart.GetComponent<Animator> ();
		GSanim.SetTrigger ("Start");
		Invoke ("LoadStart", 3f);
	}

	public void LoadStart(){
		SceneManager.LoadScene ("DefaultTut");
	}
}
