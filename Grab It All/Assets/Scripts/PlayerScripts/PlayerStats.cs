using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    private GameMaster gm;
    

    public float speed;
    public float stealSpeed;
    public float detectionSightRange;
    public float detectionNoiseRange;
    public float detectionLevel;

   // public string sceneName;

    public int totalLoot=0;

    public bool canMove = true;
    public bool makingNoise=false;
    public bool stealing=false;
    public bool watched = false;
    bool suspicious = false;

    public GameObject losePanel;

    public enum States { STEALING, NONE, WANTED, CAUGHT, HIDEN};

    public States state;

    // Start is called before the first frame update
    void Start()
    {
       // gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       //if (  gm.playerPos != Vector3.zero)
       // {
       //     //state = gm.playerStats.state;
       //     //speed = gm.playerStats.speed;
       //     //stealSpeed = gm.playerStats.stealSpeed;
       //     //detectionSightRange = gm.playerStats.detectionSightRange;
       //     //detectionNoiseRange = gm.playerStats.detectionNoiseRange;
       //     //detectionLevel = gm.playerStats.detectionLevel;

       //     transform.position = gm.playerPos;

       // }
        



        state = States.NONE;
        speed = PlayerPrefs.GetFloat("speed");
        stealSpeed = PlayerPrefs.GetFloat("stealSpeed");
        detectionSightRange = PlayerPrefs.GetFloat("detectionSightRange");
        detectionNoiseRange = PlayerPrefs.GetFloat("detectionNoiseRange");
        detectionLevel = PlayerPrefs.GetFloat("detectionLevel");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);       

        if (state != States.WANTED)
        {
            if (detectionLevel >= 80 || stealing)
                state = States.STEALING;


            if (suspicious)
            {
                detectionLevel += 0.2f;
                if (detectionLevel >= 100)
                    detectionLevel = 100;
            }

            if (state == States.HIDEN)
            {
                detectionLevel -= 0.1f;
                if (detectionLevel <= 0)
                    detectionLevel = 0;
            }
            if(state== States.NONE && !suspicious)
            {
                detectionLevel -= 0.06f;
                if (detectionLevel <= 0)
                    detectionLevel = 0;
            }
        }
        if (state == States.CAUGHT)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Death");
            losePanel.SetActive(true);
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Restricted1")
        {
            suspicious = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Camera")
        {
            state = States.WANTED;
        }
    }
}
