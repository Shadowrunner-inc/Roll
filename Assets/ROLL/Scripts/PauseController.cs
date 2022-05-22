using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) 
        {
            GameState currentGameState = GameStateManager.instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay ? GameState.Paused : GameState.Gameplay;

            GameStateManager.instance.SetState(newGameState);
        }
    }
}
