using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;

	public float movementSpeed = 20.0f;
	public bool switchCtrl;

	private Rigidbody rb;
	private Transform camTransform;

	void Awake () {

		if (instance != null)
			return;
		
		instance = this;
	}
	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody> ();
		camTransform = Camera.main.transform;
		PlayerController.instance.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		Vector3 dir = Vector3.zero;

		if (!switchCtrl) {
			
			dir.x = Input.GetAxis ("Horizontal");
			dir.z = Input.GetAxis ("Vertical");
		} else {

			dir.x = Input.GetAxis ("Horizontal2");
			dir.z = Input.GetAxis ("Vertical2");
		}

		if (dir.magnitude > 1)
			dir.Normalize ();

		// Rotate player and move based on the camera direction vector
		if (camTransform != null) {
			Vector3 rotatedDir = camTransform.TransformDirection (dir);
		
			rotatedDir = new Vector3 (rotatedDir.x, 0, rotatedDir.z);
			rotatedDir = rotatedDir.normalized * dir.magnitude;

			rb.AddForce (rotatedDir * movementSpeed);
		}
	}

	void Update () {

		Complete ();
	}

	void Complete () {

		if (Timer.LvlComplete) {

			rb.drag += 0.3f;
			movementSpeed = 0.1f;
		}
	}
}
