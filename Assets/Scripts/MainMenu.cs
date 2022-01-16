using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
	[Header ("UI Texts")]
	public TextMeshProUGUI[] mainMenuUIs;
	public TextMeshProUGUI[] gameUIs;
	public AnimationCurve curve;

	[Header ("Camera Rotation")]
	public GameObject gameManager;
	public GameObject menuCam;
	public Vector3 rotateToward;

	private bool gameStart;

    [Header("Others")]
    public GameObject sceneChange;

    // Use this for initialization
    void Start () {

		foreach (TextMeshProUGUI text in gameUIs) {

			text.color = new Color (1f, 1f, 1f, 0f);
		}

		gameManager.SetActive (false);
        sceneChange.SetActive (false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
		if (gameStart) {

			StartCoroutine (FadeOut ());
			Invoke ("RotateCamera", 2.0f);
			SwitchCamera ();
		}
    }
	// Starts the game and turns the camera pointing to the player
	public void PlayGame () {

		gameStart = true;
	}
	// Quit game
	public void Quit () {

		Application.Quit ();
		print ("Quit");
	}
	// Rotate Camera
	void RotateCamera () {

		menuCam.transform.eulerAngles = Vector3.MoveTowards(menuCam.transform.eulerAngles, rotateToward, Time.time * 100.0f);
	}
	// Switches the menuCam to playerCam
	void SwitchCamera () {

		float yAxis = menuCam.transform.eulerAngles.y;

		if (yAxis >= 179.5f) {
			
			menuCam.SetActive (false);
			gameManager.SetActive (true);
            sceneChange.SetActive (true);
            StartCoroutine (FadeIn ());
		}
	}
	// Fades texts in when game begins
	IEnumerator FadeIn () {
			
		float t = 1f;

		while (t > 0f) {

			t -= Time.deltaTime * 0.5f;
			float a = curve.Evaluate (t);

			for (int i = 0; i < gameUIs.Length; i++)
				gameUIs[i].color = new Color (1f, 1f, 1f,a);
			
			yield return 0;
		}
	}
	// Fades texts out when game begins
	IEnumerator FadeOut () {

		float t = 0f;

		while (t < 1f) {

			t += Time.deltaTime * 0.5f;
			float a = curve.Evaluate (t);

			for (int i = 0; i < mainMenuUIs.Length; i++)
				mainMenuUIs[i].color = new Color (1f, 1f, 1f,a);
			
			yield return 0;
		}
	}
}
