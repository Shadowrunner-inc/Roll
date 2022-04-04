using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTimes : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text[] DisplayText;

    void Start()
    {

        for(int index = 0;  index < DisplayText.Length; index++)
        {
            DisplayText[index].text = HighScoreManager.GetAllScores()[index];
        }


    }

    
}
