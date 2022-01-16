using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

	public Image img;
	public AnimationCurve curve;

	void Start () {

		StartCoroutine (FadeIn ());
	}

	public void FadeTo () {

		StartCoroutine (FadeOut ());
	}

	IEnumerator FadeIn () {

		float t = 1f;

		while (t > 0f) {

			t -= Time.deltaTime;
			float a = curve.Evaluate (t);
			img.color = new Color (1f, 1f, 1f, a);
			yield return 0;
		}
	}

	IEnumerator FadeOut () {

		float t = 0f;

		while (t < 1f) {

			t += Time.deltaTime * 0.6f;
			float a = curve.Evaluate (t);
			img.color = new Color (1f, 1f, 1f, a);
			yield return 0;
		}
	}
}
