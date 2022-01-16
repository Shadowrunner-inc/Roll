using UnityEngine;

public class Obstacle : MonoBehaviour {

	[Header ("Moving Obstacle")]
	public bool move;
	public float moveSpeed = 5.0f;
	public float startWaitTime = 1.0f;
	public Vector3[] moveToward;

	private float waitTime;
	private int currentPoint;

	[Header ("Rotating Obstacle")]
	public bool rotate;
	public float rotateSpeed = 5.0f;
	public Vector3 rotateToward;

	[Header ("Spawn Obstacle")]
	public bool spawn;
    public GameObject[] projectiles;
    public Vector3 size;
	public float spawnDuration = 3.0f;
	public float spawnCooldown = 2.0f;

	private float spawnWaitTime;

	void Start () {
		
		waitTime = startWaitTime;
		spawnWaitTime = spawnCooldown;
	}

	void FixedUpdate () {
		// Move object
		if (move)
			Invoke ("Move", startWaitTime);
		// Rotate object
		if (rotate)
			Rotate ();
		if (spawn)
			Invoke ("SpawnObject", startWaitTime);
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
	// Instantiate objects
	void SpawnObject () {
		
		Vector3 pos = transform.position + new Vector3 (Random.Range (-size.x / 2, size.x / 2), Random.Range (-size.y / 2, size.y / 2), Random.Range (-size.z / 2, size.z / 2));

		if (spawnWaitTime <= 0) {

            GameObject projectileIns = (GameObject)Instantiate(projectiles[Random.Range(0, projectiles.Length)], pos, Quaternion.identity);
            Destroy (projectileIns, spawnDuration);

			spawnWaitTime = spawnCooldown;
		} else {

			spawnWaitTime -= Time.deltaTime;
		}
	}
	// Allows to see the area of which the projectiles will be spawned
	void OnDrawGizmosSelected () {

		Gizmos.color = new Color (1.0f, 0.0f, 0.0f, 0.5f);
		Gizmos.DrawCube (transform.position, size);
	}
}
