using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ControlUI : MonoBehaviour
{
    public Image[] images;
    public AnimationCurve curve;

    private float delayTime = 3.6f;
    private float startTime;
    private bool fadeUI;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        delayTime -= Time.deltaTime;

        if (delayTime <= 0f && !fadeUI)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                fadeUI = true;
                StartCoroutine(FadeIn());
            }
        }
    }

    IEnumerator FadeIn()
    {
        float t = 1f;

        while (t > 0f)
        {
            foreach(Image ui in images)
            {
                t -= Time.deltaTime * 0.6f;
                float a = curve.Evaluate(t);
                ui.GetComponent<Image>().color = new Color(1f, 1f, 1f, a);
                yield return 0;
            }
        }
    }

    IEnumerator FadeOut()
    {
        float t = 0f;

        while (t < 1f)
        {
            foreach (Image ui in images)
            {
                t += Time.deltaTime * 0.6f;
                float a = curve.Evaluate(t);
                ui.GetComponent<Image>().color = new Color(1f, 1f, 1f, a);
                yield return 0;
            }
        }
    }
}
