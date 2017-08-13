using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Countdown : MonoBehaviour
{
	public Text text;
	public float timeLeft;
	public GameObject timer;
	public Timer timeScript; 
	public Text scoreText;

	void Start(){
		timer = GameObject.Find ("Timer");
		timeScript = timer.GetComponent<Timer> ();
	}

	void Update()
	{
		float minutes = Mathf.Floor(timeLeft / 60);
		float seconds = Mathf.Floor(timeLeft % 60);
		timeLeft = timeScript.timeLeft;
		text.text = minutes + ":" + seconds;
		scoreText.text = "" + timeScript.score;
	}
}
