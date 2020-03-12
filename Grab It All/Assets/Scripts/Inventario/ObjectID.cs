using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectID : MonoBehaviour
{
    public Inventory inventario;
    public int ID;
    public bool canOpen;
    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ID == 45)
        {
            if (inventario.FindItemInInventory(6)!=null)
            {
                canOpen = true;
            }
        }
        if (ID == 50)
        {
            if (inventario.FindItemInInventory(3) != null)
            {
                canOpen = true;
            }
        }

    }
}
