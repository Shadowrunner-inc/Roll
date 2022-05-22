using UnityEngine;

public class Transparent : MonoBehaviour {

	public Material clear;
	[HideInInspector]
	public float start;

	private Renderer render;
	private Material original;

	// Use this for initialization
	void Start () {
		
		render = gameObject.GetComponent <Renderer> ();

		if (render != null) {
			
		original = render.material;
		render.material = clear;
		start = Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Time.time - start > 0.5f) {
			
			if (render != null)
				render.material = original;
			
			Destroy (this);
		}
	}
}
