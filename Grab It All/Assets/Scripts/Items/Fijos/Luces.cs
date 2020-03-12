using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luces : Items
{
    private void Start()
    {
        var cf = Instantiate(itemBase.Model, new Vector3(transform.position.x, transform.position.y, transform.position.z), this.transform.rotation);
        cf.transform.SetParent(this.transform);
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
        PanelLoadBar.SetActive(true);
        BarLoad.fillAmount += 1.0f / itemBase.TimeCast * Time.deltaTime;
        if (BarLoad.fillAmount >= 1.0f)
        {
            BarLoad.fillAmount = 1.0f;
            End = true;
        }
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
            //other.GetTargetInteract(this);
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
            //other.DestroyTargetInteract(this);
        }


    }

    public override void GetAmount()
    {
        if (End == true)
        {

        }
    }
}
