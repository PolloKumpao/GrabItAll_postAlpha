using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armario : Items
{
    public objetivosController controller;
    public Animator anim;
    public Inputs inputPlayer;

    private void Start()
    {
        inputPlayer = GetComponent<Inputs>();
        PanelText.SetActive(false);
        PanelLoadBar.SetActive(false);
        TextToUse.text = itemBase.TextUI;
    }
    public override void GetOrInteract()
    {
        base.GetOrInteract();
    }

    public override void Interact()
    {
        if (controller.numeroObjetivo == 12)
        {
            Debug.Log("armario");
           
        }
        anim.SetTrigger("Open");
        
    }
    public override void Stoped()
    {
        base.Stoped();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PanelText.SetActive(true);
            if (Input.GetButtonDown(_keyF))
            {
                GetOrInteract();
               
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PanelLoadBar.SetActive(false);
            PanelText.SetActive(false);

            if (!(BarLoad.fillAmount >= 1.0f))
            {
                BarLoad.fillAmount = 0.0f;
            }
        }


    }

    public override void GetAmount()
    {
        if (End == true)
        {

        }
    }
}
