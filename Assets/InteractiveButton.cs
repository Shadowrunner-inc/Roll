using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveButton : MonoBehaviour
{
   [SerializeField] UnityEngine.Events.UnityEvent Interact;


    private void OnTriggerEnter(Collider other)
    {
        Interact.Invoke();
    }

    void ButtonPressed() {
        print(gameObject.name + ": Button Pressed");
    }
}
