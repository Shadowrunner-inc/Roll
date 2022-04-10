using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    //public UnityEngine.UI.Text bestTimeT;
    private string _SceneName;

    // When Called if the instance is null spawn and assign a new instance.
    #region Singelton
    private static HighScoreManager _instance;
    public static HighScoreManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new HighScoreManager();
            }
            return _instance;
        }
    }
    #endregion

    void Start()
    {
        print("Highscore Saver is Here!");
        _SceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        //bestTimeT = GetComponent<UnityEngine.UI.Text>();
        //bestTimeT.text = PlayerPrefs.GetFloat( _SceneName + " Best Time: ", 0).ToString();
    }

   /*private void Update()
    {
      if (Input.GetKeyDown(KeyCode.G)) UpdateScore(_SceneName);
      if (Input.GetKeyDown(KeyCode.C)) ClearAllScores();
    }*/

    public static void UpdateScore(string sceneName)
    {
        print("Save Time");
        if (Timer.time < PlayerPrefs.GetFloat(sceneName, 800.0f))
        {
            PlayerPrefs.SetFloat(sceneName, /*Timer.time*/ Timer.time);
            //print(PlayerPrefs.GetFloat(sceneName + ": ", 0).ToString());
        }
    }

    public static void ClearAllScores() {
        for (int s = UnityEngine.SceneManagement.SceneManager.sceneCount; s > 0; s--)
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(s - 1).name;
            PlayerPrefs.SetFloat(sceneName, 9000f);
        }
    }

    public static float GetScore(string sceneName) {
        float score = 0f;
        score = PlayerPrefs.GetFloat(sceneName, 800.0f);
        return score;
    }

    public static List<string> GetAllScores() {
        List<string> Scores = new List<string>();
        
        for (int s = UnityEngine.SceneManagement.SceneManager.sceneCount; s > 0; s--)
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(s - 1).name;
            float score = PlayerPrefs.GetFloat(sceneName, 9000f);

            if (score > 0.0f)
            {
                Scores.Add(sceneName + score);
            }
        }

        return Scores;
    }
}