using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody _Rigi;
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
