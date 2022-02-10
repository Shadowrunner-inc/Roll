using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody _Rigi;

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
        //assign the scripts enabled to the current gamestate
        enabled = newGameState == GameState.Gameplay;
    }

    // Start is called before the first frame update  
    void Start()
    {
        _Rigi = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = _Rigi.position;

        _Rigi.position += Vector3.back * speed * Time.fixedDeltaTime;
        _Rigi.MovePosition(pos);
    }
}
