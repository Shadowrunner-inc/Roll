using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	[Header ("Moving Platform")]
	public bool move;
	public bool holdPlayer = true;
	public GameObject player;
	public float moveSpeed = 5.0f;
	public float startWaitTime = 1.0f;
	public Vector3[] moveToward;

	private float waitTime;
	private int currentPoint;

	[Header ("Rotating Obstacle")]
	public bool rotate;
	public float rotateSpeed = 5.0f;
	public Vector3 rotateToward;

	[Header ("Hidden Platform")]
	public bool hide;

	private MeshRenderer rend;

	void Start () {

		waitTime = startWaitTime;

		if (hide) {
			
			rend = GetComponent<MeshRenderer> ();
			rend.enabled = false;
		}
	}

	void FixedUpdate () {
		
		if (move) {
			
			Invoke ("Move", startWaitTime);
		}
	}
	// Moves the platform to the designated locations
	void Move () {

		transform.position = Vector3.MoveTowards (transform.position, moveToward [currentPoint], moveSpeed * Time.deltaTime);

		if (Vector3.Distance (transform.position, moveToward [currentPoint]) < 0.2f) {

			if (waitTime <= 0) {

				currentPoint++;

				if (currentPoint >= moveToward.Length)
					currentPoint = 0;
				
				waitTime = startWaitTime;
			} else {

				waitTime -= Time.deltaTime;
			}
		}
	}
	// Rotate the object
	void Rotate () {

		transform.Rotate (rotateToward * rotateSpeed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision other) {
		// Holds the player when they go on top of the platform	
		if (player.gameObject == player && holdPlayer && move)
			player.transform.parent = gameObject.transform;
		// Reveals hidden platform when player collide with the object
		if (other.gameObject.tag == "Player" && hide)
			rend.enabled = true;
	}

	void OnCollisionExit (Collision other) {
		// Let go of the player when they exit the platform
		if (player.gameObject == player && holdPlayer && move)
			player.transform.parent = null;
	}
}
