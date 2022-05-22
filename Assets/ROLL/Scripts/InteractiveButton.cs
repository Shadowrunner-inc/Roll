using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButton : MonoBehaviour
{
   [SerializeField] UnityEngine.Events.UnityEvent Interact;
    
    #region GameState Logic
    // Update is called once per frame
    void Awake()
    {
        //Subscribe to gameStateManager's state change event
        GameStateManager.instance.OnGameStateChange += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        //Unsubscribe to gameStateManager's state change event
        GameStateManager.instance.OnGameStateChange -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        gameObject.SetActive(newGameState == GameState.Gameplay);
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        Interact.Invoke();
    }

    void ButtonPressed() {
        print(gameObject.name + ": Button Pressed");
    }
}
