using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    private bool opened=false;
    private bool paused = false;
    public bool hiden = false;

    public int guardsSize;
    public int npcsSize;

    public GameObject pausePanel;
    public objetivosController controller;
    private PlayerStats stats;
    public Inventory inventory;
    private Animator anim;
    private ObjectID ID;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        // inventory = GetComponent<Inventory>();
        stats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!paused)
            {
                for (int i = 0; i < guardsSize; ++i)
                {
                    GameObject.FindWithTag("Guard").GetComponent<patrol>().enabled = false;
                }
                for (int i = 0; i < npcsSize; ++i)
                {
                    GameObject.FindWithTag("NPC").GetComponent<patrol>().enabled = false;
                }
                GetComponent<movement>().enabled = false;

                pausePanel.SetActive(true);
            }
            else
            {
                for (int i = 0; i < guardsSize; ++i)
                {
                    GameObject.FindWithTag("Guard").GetComponent<patrol>().enabled = true;
                }
                for (int i = 0; i < npcsSize; ++i)
                {
                    GameObject.FindWithTag("NPC").GetComponent<patrol>().enabled = true;
                }
                GetComponent<movement>().enabled = true;

                pausePanel.SetActive(false);
            }
            paused = !paused;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Armario")
        {
            if(hiden)
            {
                stats.state = PlayerStats.States.HIDEN;
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                anim = GetComponent<Animator>();
                Debug.Log("f");
                if (!hiden)
                {
                    anim.ResetTrigger("Salir");
                    anim.SetTrigger("Esconderse");
                    if (controller.numeroObjetivo == 12)
                        controller.numeroObjetivo++;
                }
                else if(hiden)
                {
                    anim.ResetTrigger("Esconderse");
                    anim.SetTrigger("Salir");
                }
                hiden = !hiden;
            }
        }
        if (other.gameObject.tag == "CajaFuerte")
        {
            if (Input.GetKey(KeyCode.F))
            {
                ID = other.gameObject.GetComponent<ObjectID>();

                if (ID.ID==50)
                {
                    if (inventory.FindItemInInventory(3) != null)
                    {
                        if (!ID.canOpen)
                        {
                            ID.canOpen = true;
                            stats.stealing = true;
                        }
                    }
                }
                if (ID.ID == 45)
                {
                    if (inventory.FindItemInInventory(6) != null)
                    {
                        if (!ID.canOpen)
                        {         
                            stats.stealing = true;
                            ID.canOpen = true;
                        }
                    }
                }
            }
            stats.stealing = false;
        }
        if (other.gameObject.tag == "Alarma")
        {

            Alarm alarm;
            if (Input.GetKey(KeyCode.F))
            {
                alarm = other.gameObject.GetComponent<Alarm>();

                alarm.setOn();
                // alarm.hack();

            }
        }
    }
}
