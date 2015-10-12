using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProgrammerController : MonoBehaviour {

	private float speed = 0;
	private float lastKeyPress = 0;

	private float startTime = 0;
	private float winTime = 0;
	private bool hasWon;

	private float winCount = 1000;
	private float typeCount = 0;

	private GameObject bar;
	private Text infopanel;

	private 

	// Use this for initialization
	void Start () {
		GetComponent<Animator> ().speed = 0;
		bar = GameObject.Find("green_bar");
		bar.transform.localScale =  new Vector2(0f, 1f);

		infopanel = GameObject.Find("infopanel").GetComponent<Text>();
	}

	void OnWin() {
		if (!hasWon) {
			hasWon = true;
			infopanel.text = "You completed your game in " + winTime.ToString () + " seconds!!!";
			GameObject.Find ("ReplayBtn").GetComponent<Animator> ().Play ("ReplayAnim");
		}
	}

	
	// Update is called once per frame
	void Update () {
		float s = 10 / ((Time.time - lastKeyPress) * 20);
		float winPrctn = typeCount/winCount;

		GetComponent<Animator> ().speed = Mathf.RoundToInt(s);

		//Game logic
		if (winPrctn <= 1 &&  Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)) {
			if(typeCount == 0) {
				startTime = Time.time;
			}

			typeCount++;
			lastKeyPress = Time.time;

			if(winPrctn > 1) {
				return;
			}

			bar.transform.localScale =  new Vector2(winPrctn, 1f);
		}

		//text logic
		if (typeCount > 0 && winPrctn <= 1) {
			winTime = Mathf.RoundToInt(Time.time - startTime);
			string time = Mathf.RoundToInt (Time.time - startTime).ToString ();
			infopanel.text = time + " Seconds";
		} else if(typeCount > 0) {
			OnWin();
		}

	}

	public void Restart() {
		Application.LoadLevel(Application.loadedLevel);
	}
	
}
