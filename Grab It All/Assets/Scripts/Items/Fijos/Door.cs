using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Door : ItemsCloosers
{

    public Animator anim;
    public ObjectID ID;
    public bool opened = false;
    public bool PlayerContact = false;

    public Vector3 Scale;
    private void Start()
    {
        //var cf = Instantiate(itemBase.Model, new Vector3(transform.position.x, transform.position.y, transform.position.z), this.transform.rotation);
        //cf.transform.SetParent(this.transform);
        //cf.transform.localScale = (Scale);
        //anim = cf.GetComponentInChildren<Animator>();
        inventory = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventory>();
        PanelText.SetActive(false);
        PanelLoadBar.SetActive(false);
        TextToUse.text = itemBase.TextUI;
        //Canvas tmp = this.GetComponentInChildren<Canvas>();
        //tmp.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        //tmp.planeDistance = 5.0f;
        //CanvasScaler tmpCS = this.GetComponentInChildren<CanvasScaler>();
        //tmpCS.referenceResolution = new Vector2(1920.0f, 1080.0f);

    }

    public override void GetOrInteract()
    {
        base.GetOrInteract();
    }

    public override void Interact()
    {
        if(anim == null)
        anim = this.GetComponentInChildren<Animator>();

        if (ID.ID == 0)
        {
            if (!opened)
            {
                anim.SetBool("open", true);
            }
            else
                anim.SetBool("open", false);

            opened = !opened;
        }
        else if (ID.ID == 10 && inventory.FindItemInInventory(1) != null)
        {
            if (!opened)
            {
                anim.SetBool("open", true);
            }
            else
                anim.SetBool("open", false);

            opened = !opened;
        }
        else if (ID.ID == 20 && inventory.FindItemInInventory(7) != null)
        {
            if (!opened)
            {
                anim.SetBool("open", true);
            }
            else
                anim.SetBool("open", false);

            opened = !opened;
        }
        else
            Debug.Log("cant open");

}
    public override void Stoped()
    {
        base.Stoped();
    }

    public override void Craf()
    {

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
                TextToUse.text = "Pulsa[F] para Abrir.";
            }
        }

    }
    public override void Drop()
    {
        Debug.Log("Poner en el inventario");

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerContact = true;

            PanelText.SetActive(true);
            if (Input.GetButtonDown(_keyF))
            {
                anim = this.gameObject.GetComponentInChildren<Animator>();
                ID = this.GetComponent<ObjectID>();
                GetOrInteract();
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
