using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{

    ObjectID objeto;
    Inventory inventory;
    public GameObject inventario;

    enemyScript enemyScript;


    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Collectable")
        {
            objeto = other.gameObject.GetComponent<ObjectID>();
            if(Input.GetKeyUp(KeyCode.F))
            {
                inventory = inventario.GetComponent<Inventory>();
                inventory.AddItem(objeto.ID);
                Destroy(other.gameObject);               
            }
        }
        if (other.gameObject.tag == "StealRange")
        {
            enemyScript = other.gameObject.GetComponentInParent<enemyScript>();
            if (Input.GetKeyUp(KeyCode.F))
            {
                inventory = inventario.GetComponent<Inventory>();
                inventory.AddItem(enemyScript.itemEnemyID);
                Destroy(other.gameObject);

            }
        }
    }
}
