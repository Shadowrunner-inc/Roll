using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TMPro.TMP_Text))]
public class DisplayTime : MonoBehaviour
{ 
    [SerializeField] string levelName;

    void Start()
    {
        GetComponent<TMPro.TMP_Text>().text ="Best Time: " + HighScoreManager.GetScore(levelName);
    }
}
