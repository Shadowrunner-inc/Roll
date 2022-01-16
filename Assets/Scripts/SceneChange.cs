using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public string loadScene;
	public SceneFader sceneFader;

	void OnTriggerEnter (Collider other) {

		if (other.gameObject.tag == "Player") {
			
			Timer.LvlComplete = true;
			CameraController.playing = false;
			sceneFader.FadeTo ();
			Invoke ("ChangeScene", 1.8f);
		}
	}

	void ChangeScene () {
		
		SceneManager.LoadScene (loadScene);
	}
}
