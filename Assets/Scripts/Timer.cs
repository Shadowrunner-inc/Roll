using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {

	PlayerController playerControl;

	public TextMeshProUGUI timerText;
	public TextMeshProUGUI counterText;

	static public float time;
	static public bool LvlComplete;
	private float delayTime = 3.6f;
	public float moreDelayTime;
	private float startTime;

	// Allows to continue the timer to the next scene
	void Awake () {
		
		DontDestroyOnLoad(this);
	}
	// Use this for initialization
	void Start () {
		// Must make LvlComplete false at beginning of every level
		playerControl = PlayerController.instance;
		startTime = time;
		LvlComplete = false;

		Invoke ("MoveCamera", delayTime + moreDelayTime);
	}
	void MoveCamera () {

		CameraController.playing = true;
	}
	// Update is called once per frame
	void Update () {
		
		delayTime -= Time.deltaTime;

		// Countdown time before the player can move and play
		if (delayTime >= 2.6f) {

			counterText.text = "";
		} else if (delayTime >= 2.0f) {

			counterText.text = "3";
		} else if (delayTime >= 1.4f) {
			
			counterText.text = "2";
		} else if (delayTime >= 0.8f) {

			counterText.text = "1";
		} else if (delayTime >= 0.2f) {

			counterText.text = "GO!";
			counterText.color = Color.red;
			counterText.fontSize = 50;
		} else if (delayTime >= -0.4f) {

			counterText.enabled = false;
		}
		// Once READY, SET, GO! is over, player can move and play
		if (delayTime <= 0f && playerControl != null && !LvlComplete) {

			playerControl.enabled = true;
			time = startTime - delayTime;
		}
		TimeCount ();
	}
	// Counts time
	void TimeCount () {
		
		if (timerText != null) {

			float minutes = ((int)time / 60);
			float seconds = ((int)time % 60);
			float millseconds = ((int)(time * 100)) % 100;

			timerText.text = string.Format ("{0:0}:{1:00}:{2:00}", minutes, seconds, millseconds);
		}
	}
}
