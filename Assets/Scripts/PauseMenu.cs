using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public GameObject ui;
	[SerializeField] int mainMenuIndex;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.P)) {

			Toggle ();
		}
	}

	public void Toggle () {

		ui.SetActive (!ui.activeSelf);

		if (ui.activeSelf) {

			Time.timeScale = 0f;
		} else {

			Time.timeScale = 1f;
		}
	}

	public void Retry () {

		Toggle ();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

	public void Menu () {
		Toggle();
		//SceneManager.LoadScene(mainMenuIndex);
		print ("menu");
	}
	public void QuitGame() { Application.Quit(); }
}
