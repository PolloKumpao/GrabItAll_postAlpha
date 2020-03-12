using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsLanzables : Items
{
    public LineRenderer lr;

    public float distance = 1.0f;
    public bool useInitalCameraDistance = false;

    protected float actualDistance = 10.0f;
    public int speed;
    public float shootVel;
    public bool shootGo;

    protected Vector3 DirectionShoot;
    protected Vector3 mousePosition;
    protected Vector3 ShootPosition;

    public SphereCollider sc;

    public Rigidbody rb;


    public virtual void Throught()
    {
        PanelLoadBar.SetActive(false);
        PanelText.SetActive(false);

        if (!(BarLoad.fillAmount >= 1.0f))
        {
            BarLoad.fillAmount = 0.0f;
        }

        if (!shootGo)
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = actualDistance;
        }
        
        lr.SetPosition(0, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z));
        lr.SetPosition(1, (Camera.main.ScreenToWorldPoint(mousePosition)));

        // Click y lanzar
        if (Input.GetMouseButtonDown(0))
        {
            shootGo = true;
        }
        
    }

    public virtual void Shoot()
    {

    }
}
