using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public float collisionDuration = 3.0f;

	private float colDurTime;

    // Start is called before the first frame update
    void Start()
    {
		colDurTime = collisionDuration; 
    }

    // Update is called once per frame
    void Update()
    {
		if (colDurTime <= 0) {

			gameObject.tag = "Untagged";
		} else {
			
			colDurTime -= Time.deltaTime;
		}
    }
}
