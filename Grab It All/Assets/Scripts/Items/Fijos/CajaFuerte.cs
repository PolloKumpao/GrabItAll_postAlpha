using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CajaFuerte : Items
{
    
    public Animator anim;
    public ObjectID ID;
    private bool opened = false;
    public Vector3 Scale;
    public bool PlayerContact = false;
    public objetivosController objetivoscontroller;


    private void Start()
    {
        var cf = Instantiate(itemBase.Model, new Vector3(transform.position.x, transform.position.y, transform.position.z), this.transform.rotation);
        cf.transform.SetParent(this.transform);
        cf.transform.localScale = (Scale);
        anim = cf.GetComponentInChildren<Animator>();
        PanelText.SetActive(false);
        PanelLoadBar.SetActive(false);
        TextToUse.text = itemBase.TextUI;
        //Canvas tmp = this.GetComponentInChildren<Canvas>();
        //tmp.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //tmp.planeDistance = 5.0f;
        //CanvasScaler tmpCS = this.GetComponentInChildren<CanvasScaler>();
        //tmpCS.referenceResolution = new Vector2(1920.0f, 1080.0f);
        ID = GetComponent<ObjectID>();
    }
    public override void GetOrInteract()
    {
        base.GetOrInteract();
    }
    private void Update()
    {
        if (PlayerContact)
        {
            if (opened)
            {
                TextToUse.text = "Pulsa[F] para Cerrar.";
            }
            else
            {
                TextToUse.text = "Pulsa[F] para Robar.";
            }
        }

    }
    public override void Interact()
    {

        if (ID.canOpen && !opened)
        {
            if (anim == null)
                anim = this.GetComponentInChildren<Animator>();

            PanelLoadBar.SetActive(true);
            BarLoad.fillAmount += 1.0f / itemBase.TimeCast * Time.deltaTime;
            if (BarLoad.fillAmount >= 1.0f)
            {
                BarLoad.fillAmount = 1.0f;
                End = true;
                if (!opened)
                {
                    anim.SetBool("Open", true);

                    if (!Droped)
                    {
                        stats.totalLoot += ID.amount;
                        Droped = true;

                        if (objetivoscontroller.numeroObjetivo == 6)
                            objetivoscontroller.numeroObjetivo++;

                        if (objetivoscontroller.numeroObjetivo == 15)
                            objetivoscontroller.numeroObjetivo++;

                        if (ID.ID == 50)
                        inventory.RemoveItem(3);

                        if (ID.ID == 45)
                            inventory.RemoveItem(6);
                    }

                    opened = true;

                }


            }
        }
    }
    public override void Stoped()
    {
        base.Stoped();
    }
    public override void Craf()
    {
        Debug.Log("No Craft Aviable");
    }

    public override void Drop()
    {
        Debug.Log("No Drop Aviable");
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerContact = true;
            stats = other.GetComponent<PlayerStats>();

            PanelText.SetActive(true);

            if (Input.GetButton(_keyF))
            {
                PanelLoadBar.SetActive(true);
                GetOrInteract();
            }
            else
            {
                PanelLoadBar.SetActive(false);
                if (BarLoad.fillAmount == 1.0f)
                    BarLoad.fillAmount = 0.0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerContact = false;

            PanelLoadBar.SetActive(false);
            PanelText.SetActive(false);
            Stoped();

            if(BarLoad.fillAmount == 1.0f)
                BarLoad.fillAmount = 0.0f;
        }
    }

    public override void GetAmount()
    {
        if (End == true)
        {

        }
    }
}
