using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	[SerializeField] int titleSceneIndex;
	[SerializeField] RectTransform mainPanel, optionsPanel, controlsPanel;

    #region GameState Logic
    // Update is called once per frame
    void Awake () {
		//Subscribe to gameStateManager's state change event
		GameStateManager.instance.OnGameStateChange += OnGameStateChanged;
	}

    private void OnDestroy()
    {
		//Unsubscribe to gameStateManager's state change event
		GameStateManager.instance.OnGameStateChange -= OnGameStateChanged;
	}

    private void OnGameStateChanged(GameState newGameState) {
		//gameObject.SetActive(newGameState == GameState.Paused);
		Reset();
		mainPanel.gameObject.SetActive(newGameState == GameState.Paused);
		
	}
    #endregion

	public void Resume() { GameStateManager.instance.SetState(GameState.Gameplay); }
    public void Retry () {
		Resume();
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex); 
	}

	public void GoToTitle()
	{
		Resume();
		SceneManager.LoadScene(titleSceneIndex);
	}

	public void TitleMenu () {
		//SceneManager.LoadScene(mainMenuIndex);
		print ("menu");
	}
	public void QuitGame() { Application.Quit(); }

    private void Reset()
    {
		mainPanel.gameObject.SetActive(false);
		optionsPanel.gameObject.SetActive(false);
		controlsPanel.gameObject.SetActive(false);
    }
	
}
