using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmEfect : MonoBehaviour
{

    public CanvasGroup canvas;
    GameObject player;
    public PlayerStats playerStats;
    public float Duration = 0.4f;
    public bool mfaded;
    float start;
    float end;
    float counter = 0f;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponentInParent<CanvasGroup>();
        mfaded = false;
        player = GameObject.Find("MainMalePlayer");
        playerStats = player.GetComponents<PlayerStats>()[0];
     
    }

    // Update is called once per frame
    void Update()
    {
        fade();
    }
    public void fade()
    {
       
        if (playerStats.detectionLevel >= 70)
        {
            
            if (canvas.alpha == 0)
            {
                start = 0;
                end = 0.7f;
                counter = 0f;
            }
            if (canvas.alpha == 0.7f)
            {
                start = 0.7f;
                end = 0;
                counter = 0f;
            }
           

                //Debug.Log("fade");
                
               
                    counter += Time.deltaTime;
                    canvas.alpha = Mathf.LerpAngle(start, end, counter );


                
                mfaded = !mfaded;
            

            
        }
        else if (canvas.alpha != 0)
        {

            start = 0.7f;
            end = 0;
          
            counter += Time.deltaTime;
            canvas.alpha = Mathf.LerpAngle(start, end, counter);


        }


    }
    //public IEnumerator DoFade(CanvasGroup canvas, float start, float end)
    //{
    //    Debug.Log("fade");
    //    float counter = 0f;
    //    while (counter < Duration)
    //    {
    //        counter += Time.deltaTime;
    //        canvas.alpha = Mathf.Lerp(start, end, counter / Duration);
            
    //        yield return null;
    //    }

    //}
}
