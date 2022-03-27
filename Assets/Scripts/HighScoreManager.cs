using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    //public UnityEngine.UI.Text bestTimeT;
    private string _SceneName;

    void Start()
    {
        print("Highscore Saver is Here!");
        _SceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        //bestTimeT = GetComponent<UnityEngine.UI.Text>();
        //bestTimeT.text = PlayerPrefs.GetFloat( _SceneName + " Best Time: ", 0).ToString();
    }

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) UpdateScore(_SceneName);
        if (Input.GetKeyDown(KeyCode.C)) ClearAllScores();
    }*/

    public static void UpdateScore(string sceneName)
    {
        print("Save Time");
        if (Timer.time < PlayerPrefs.GetFloat(sceneName + " Time: ", 800.0f))
        {
            PlayerPrefs.SetFloat(sceneName + " Time: ", /*Timer.time*/ Timer.time);
            //print(PlayerPrefs.GetFloat(sceneName + ": ", 0).ToString());
        }
       
    }

    public static void ClearAllScores() {


        for (int s = UnityEngine.SceneManagement.SceneManager.sceneCount; s > 0; s--)
        {
            string sceneName = UnityEngine.SceneManagement.SceneManager.GetSceneAt(s-1).name;
            PlayerPrefs.SetFloat(sceneName + " Time: ", 9000f); 
        }

    }
}
