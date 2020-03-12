using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Menu : MonoBehaviour
{

    [SerializeField]
    private Canvas Inventario;
    [SerializeField]
    private Canvas Crafteo;
    private bool inventoryisClosed;
    private bool craftisClosed;
    // Start is called before the first frame update
    void Start()
    {
        inventoryisClosed = true;
        craftisClosed = true;
        Inventario.enabled = false;

        Crafteo.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.I))
        {
            if(inventoryisClosed)
            {
                if(craftisClosed)
                {
                    OpenInventory();
                }
                else
                {
                    CloseCraft();
                    OpenInventory();
                }
              
            }
            else
            {
                CloseInventory();
            }
        }

        if (Input.GetKeyUp(KeyCode.C))
        {
            if (craftisClosed)
            {
                if (inventoryisClosed)
                {
                    OpenCraft();
                }
                else
                {
                    CloseInventory();
                    OpenCraft();
                }

            }
            else
            {
                CloseCraft();
            }
        }

    }
    void OpenInventory()
    {
        Inventario.enabled = true;
        inventoryisClosed = false;
    }
    void CloseInventory()
    {
        Inventario.enabled = false;
        inventoryisClosed = true;
    }
    void OpenCraft()
    {
        Debug.Log("abierto");
        Crafteo.enabled = true;
        craftisClosed = false;
    }
    void CloseCraft()
    {
        Crafteo.enabled = false;
        craftisClosed = true;
    }
}
