using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	public Material transparent;
	public bool switchCtrl;

	public static bool playing;
	public static bool camReturn;
	private Vector3 desiredPosition;
	private Vector3 offset;

	private float smoothSpeed = 7.5f;
	private float distance = 14.0f;
	private float yOffset = 8.0f;

	// Use this for initialization
	void Start () {

		offset = new Vector3 (0, yOffset, 1f * distance);
	}

	// Update is called once per frame
	void Update () {
		// When playing is true, it will allow players to move the camera
		if (playing) {
			if (!switchCtrl) {
				
				if (Input.GetKeyDown (KeyCode.LeftArrow))
					SlideCamera (true);
				else if (Input.GetKeyDown (KeyCode.RightArrow))
					SlideCamera (false);
			} else {

				if (Input.GetKeyDown (KeyCode.A))
					SlideCamera (true);
				else if (Input.GetKeyDown (KeyCode.D))
					SlideCamera (false);
			}
		}
		// Return the camera to original position if the player respawns
		if (camReturn) {
			
			offset = new Vector3 (0, yOffset, 1f * distance);
			camReturn = false;
		}
	}

	void FixedUpdate () {
		// Moves the camera and faces the player
		desiredPosition = player.position + offset;
		transform.position = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.LookAt (player.position + Vector3.up);

		Transparent ();
	}
	// Make Obstacles transparent when it blocks the view of the player
	void Transparent () {
		
		RaycastHit[] hit = Physics.RaycastAll (transform.position, (player.position - transform.position).normalized, Vector3.Distance (transform.position, player.position) - 1);

		for (int x = 0; x < hit.Length; x++) {

			Transparent inv = hit [x].collider.gameObject.GetComponent <Transparent> ();

			if (inv == null) {

				inv = hit [x].collider.gameObject.AddComponent <Transparent>();
				inv.clear = this.transparent;
			} else {

				inv.start = Time.time;
			}
		}
	}

	void SlideCamera (bool left) {
		
		if (left)
			offset = Quaternion.Euler (0, 45, 0) * offset;
		else
			offset = Quaternion.Euler (0, -45, 0) * offset;
	}
}
