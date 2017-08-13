using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public GameObject[] items;
	public int randomNum;
	public float button;
	public GameObject bloodParticles;

	public GameObject timer;
	private Timer timeScript; 
	public Text GOtext;

	private Animator catanim;
	public GameObject cat;

	private Animator topanim;
	public Image TopJaw;

	private Animator botanim;
	public Image BottomJaw;

	private Animator gganim;
	public Image GGimage;

	private Animator curtainAnim;
	public GameObject curtain;

	public AudioSource buttonClick;
	public AudioSource bitingSound;
	public AudioSource catScream;
	public AudioSource winSound;
	public AudioSource glassDing;
	public AudioSource horrorSound;

	void Awake(){
		glassDing.pitch = Random.Range (0.4f, 0.8f);
	}

	void Start() {
		//DOTween.Init ();
		randomNum = Random.Range (0, items.Length);
		Debug.Log (randomNum);
		button = Mathf.Ceil((randomNum + 1f)/2f);
		Debug.Log (button);
		Animator anim = items [randomNum].GetComponent<Animator> ();
		anim.SetTrigger ("SecondState");

		curtainAnim = curtain.GetComponent<Animator> ();
		gganim = GGimage.GetComponent<Animator> ();
		topanim = TopJaw.GetComponent<Animator> ();
		botanim = BottomJaw.GetComponent<Animator> ();
		catanim = cat.GetComponent<Animator> ();

		timer = GameObject.Find ("Timer");
		timeScript = timer.GetComponent<Timer> ();
	}
		

	public void Button1(){
		if (button == 1) {
			buttonClick.Play ();
			catanim.SetInteger ("Ritual", 1);
			curtainAnim.SetTrigger ("Stop");
			Invoke ("Restart", 1.1f);
		} else if (button != 1) {
			button = 0;
			GameOver ();
		}
	}

	public void Button2(){
		if (button == 2) {
			buttonClick.Play ();
			catanim.SetInteger ("Ritual", 2);
			curtainAnim.SetTrigger ("Stop");
			Invoke ("Restart", 1.1f);
		} else if (button != 1) {
			button = 0;
			GameOver ();
		}
	}

	public void Button3(){
		if (button == 3) {
			buttonClick.Play ();
			catanim.SetInteger ("Ritual", 3);
			curtainAnim.SetTrigger ("Stop");
			Invoke ("Restart", 1.1f);
		} else if (button != 1) {
			button = 0;
			GameOver ();
		}
	}

	public void Button4(){
		if (button == 4) {
			buttonClick.Play ();
			catanim.SetInteger ("Ritual", 4);
			curtainAnim.SetTrigger ("Stop");
			Invoke ("Restart", 1.1f);
		} else if (button != 1) {
			button = 0;
			GameOver ();
		}
	}

	void Restart(){
		Debug.Log ("WIN!");
		SceneManager.LoadScene (1);
	}

	public void GameOver(){
		AudioManager.stopper = true;
		buttonClick.Play ();
		horrorSound.Play ();
		Debug.Log ("LOSER!");
		gganim.SetTrigger ("GameOver");
		Invoke ("NomNom", 2f);
	}

	void NomNom(){
		bitingSound.Play ();
		topanim.SetTrigger ("GameOver");
		botanim.SetTrigger ("GameOver");
		Invoke ("Blood", 0.4f);
		Invoke ("GOmessage", 1.5f);
		Invoke ("ToMenu", 5f);
	}

	void Blood(){
		catScream.Play ();
		bloodParticles.SetActive (true);
	}

	void GOmessage(){
		GOtext.text = "" + timeScript.score +" POSES";
		GOtext.gameObject.SetActive(true);
	}

	public void ToMenu(){
		SceneManager.LoadScene ("Menu");
	}
}
