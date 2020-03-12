using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquiped : MonoBehaviour
{
    [SerializeField]
    public Inventory inventario;
    [SerializeField]
    public DB dataBase;
    private Vector3 piedraPos;
    Objeto equipedItem;
    public GameObject piedra;

    // Start is called before the first frame update
    public void Equipar(int id)
    {
        if(inventario.FindItemInInventory(id)!=null)
        {
            if (dataBase.FindItemInDataBase(inventario.FindItemInInventory(id).itemId).dropeable)
            {
                Debug.Log(dataBase.FindItemInDataBase(inventario.FindItemInInventory(id).itemId).name);
                Debug.Log("equipado");
                equipedItem = dataBase.FindItemInDataBase(inventario.FindItemInInventory(id).itemId);
                Instantiate(piedra, piedraPos, Quaternion.identity, transform);
            }
            else
            {
                Debug.Log("No me puedo equipar eso");
            }
            
        }
    }
    public void useItem()
    {

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        piedraPos = new Vector3(transform.position.x + 0.66f, transform.position.y + 0.179f, transform.position.z + 0.52f);
    }
}
