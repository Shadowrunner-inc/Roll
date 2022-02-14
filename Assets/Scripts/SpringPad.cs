using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPad : MonoBehaviour
{
    [SerializeField] float launchForce = 20f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.GetComponent<Rigidbody>()?.AddForce(0f, launchForce, 0f, ForceMode.Impulse);
        }
    }
}
