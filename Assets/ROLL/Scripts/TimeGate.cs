using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGate : MonoBehaviour
{
    [SerializeField] float dialationsTime = 3f;
    float timer, defaultFixedDeltaTime;  
    float elapsedTime;
    
    public float desiredDuration = 15f;
    [Range(.01f,.99f)] public float slowScale = .25f;
    public float normalScale = 1f;

    public bool bSmoothTransition = true;

    // Start is called before the first frame update
    void Start()
    {
        defaultFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*Test Codes
        if (Input.GetKeyDown(KeyCode.T)) {
             if (Time.timeScale != 1f) RegularTime();
             else SlowTime();
            
        }*/
        
        //timer for how long time is Slowed.
        if (Time.timeScale != 1f) {
            timer += Time.fixedDeltaTime;
           // print(Mathf.Round(timer));
            if (timer >= dialationsTime) RegularTime(); 
        }

    }

    //Uses lerping to smoothle transitionbetween the to scales passed. Currently not reuseable for anything but time.Scale application
    private void SmoothTimeTransition(float oldScale, float newScale)
    {
        elapsedTime += Time.unscaledDeltaTime;
        float percentageComplete = elapsedTime / desiredDuration;
        Time.timeScale = Mathf.Lerp(oldScale, newScale, percentageComplete);
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;
        
        //print("Time Scale: " + Time.timeScale);

         if (percentageComplete == 1f) {
             elapsedTime = 0f;
         }
    }

    void SlowTime() {
        // snap to Scale
        Time.timeScale = slowScale; 
        Time.fixedDeltaTime = defaultFixedDeltaTime * Time.timeScale;

        /* if Smooth to Scale
        SmoothTimeTransition();
        */
    }
    void RegularTime() {

        if (bSmoothTransition)
        {
            SmoothTimeTransition(slowScale, normalScale);
        }
        else
        {
            //if snap to Scale
            Time.timeScale = 1f;
        }


        if (Time.timeScale == 1f)
        {
            timer = 0f;
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.timeScale <= 1f)
        {
            //print("PLayer enters");
            SlowTime();

        }
    }

   


}
