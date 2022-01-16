using UnityEngine;

public class Respawn : MonoBehaviour {

	public Transform playerPrefab;
	public Transform respawnPoint;
	public GameObject deathEffect;

	// Respawns when player fall off the map
	void OnTriggerEnter (Collider other) {

		if (other.tag == "Respawn") {

			playerPrefab.gameObject.SetActive (false);
			CameraController.playing = false;
			DeathEffect ();
			Invoke ("Return", 2.0f);
		}
	}
	// Respawns when player gets hit by objects
	void OnCollisionEnter (Collision other) {

		if (other.collider.tag == "Respawn") {

			playerPrefab.gameObject.SetActive (false);
			CameraController.playing = false;
			DeathEffect ();
			Invoke ("Return", 2.0f);
		}
	}
	// Respawns the player back to the start point
	void Return () {

		playerPrefab.transform.position = respawnPoint.transform.position;

		playerPrefab.gameObject.GetComponent<Rigidbody> ().isKinematic = true;
		playerPrefab.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
		CameraController.camReturn = true;

		playerPrefab.gameObject.SetActive (true);
		CameraController.playing = true;
	}
	// Instantiate death particle effects
	void DeathEffect () {

		GameObject effectIns = (GameObject)Instantiate (deathEffect, playerPrefab.transform.position, playerPrefab.transform.rotation);
		Destroy (effectIns, 2.0f);
	}
}
