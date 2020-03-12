using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lapiz : ItemsOpenings
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
        if (lvlSecurity >= key.lvlSecurity)
        {

            PanelLoadBar.SetActive(true);
            BarLoad.fillAmount += 3.0f / itemBase.TimeCast * Time.deltaTime;
            if (BarLoad.fillAmount >= 1.0f)
            {
                BarLoad.fillAmount = 1.0f;
                End = true;
            }
        }
    }

    public override void Drop()
    {
        PanelLoadBar.SetActive(true);
        BarLoad.fillAmount += 1.0f / itemBase.TimeCast * Time.deltaTime;
        if (BarLoad.fillAmount >= 1.0f)
        {
            BarLoad.fillAmount = 1.0f;
            //Poner Inventario
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

            if (Input.GetButton(_keyR))
            {
                GetOrInteract();
            }

            if (Input.GetButton(_keyQ))
            {
                lr.gameObject.SetActive(true);
                Throught();
            }
            else
            {
                lr.gameObject.SetActive(false);
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
            //other.DestroyTargetInteract(this);
        }


    }

    public override void GetAmount()
    {
        if (End == true)
        {

        }
    }


    private void Update()
    {
        if (shootGo)
        {
            Shoot();
        }
    }
    public override void Shoot()
    {
        if (shootVel == 0)
        {
            PanelLoadBar.SetActive(false);
            PanelText.SetActive(false);

            if (!(BarLoad.fillAmount >= 1.0f))
            {
                BarLoad.fillAmount = 0.0f;
            }

            Plane playerPlane = new Plane(Vector3.up, transform.position);

            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            float hitdist = 0.0f;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);

                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1f);
                shootVel = 2;
            }
        }
        rb.AddForce(transform.forward * shootVel);
        shootVel -= (shootVel * Time.deltaTime) / 2;

        if (shootVel < 0.5)
        {
            shootVel = 0;
            shootGo = false;
            rb.velocity = new Vector3(1, 1, 1) * 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.collider, sc);
        }
    }
}
