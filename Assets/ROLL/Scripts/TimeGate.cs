using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGate : MonoBehaviour
{
    [SerializeField] float dialationsTime = 3f;
    [Range(.1f,.9f)] float SlowRate = .5f;
    
    bool bTimeToggle = false;
    float timer, defaultFixedDeltaTime, defaultTimeScale;

    // Start is called before the first frame update
    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            if (Time.timeScale != 1f) RegularTime();
            else SlowTime();
        }

        //TODO: timer for how long time is Slowed.
        if (Time.timeScale != 1f) {
            timer += Time.fixedDeltaTime;
            print(Mathf.Round(timer));
            if (timer >= dialationsTime) RegularTime();

        }
    }

    void SlowTime() {
        Time.timeScale = SlowRate;
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
        //timer = dialationsTime;
        print("Time Slowed!");
    }
    void RegularTime() {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
        timer = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.timeScale <= 1f)
        {
            print("PLayer enters");
            SlowTime();
            //StartCoroutine(Slow());
        }
    }
    /*OutDated.. corotine
    IEnumerator Slow() {
        SlowTime();
        yield return new WaitForSeconds(dialationsTime);
        RegularTime();
    }*/
}
