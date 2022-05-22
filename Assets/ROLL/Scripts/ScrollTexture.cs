using UnityEngine;

public class ScrollTexture : MonoBehaviour {

	public float scrollX = 0.001f;
	public float scrollY = 0.001f;

	// Update is called once per frame
	void Update () {

		float OffsetX = Time.time * scrollX;
		float OffsetY = Time.time * scrollY;

		GetComponent<Renderer> ().material.mainTextureOffset = new Vector2 (OffsetX, OffsetY);
	}
}
