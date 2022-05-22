using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string loadScene;
    public SceneFader sceneFader;

    private bool gameStart;
    // Update is called once per frame
    void Update()
    {
		if (gameStart) {

            sceneFader.FadeTo();
            Invoke("ChangeScene", 1.8f);
        }
    }
    void ChangeScene() {

        SceneManager.LoadScene(loadScene);
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
}
