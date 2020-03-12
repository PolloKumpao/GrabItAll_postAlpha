using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftHandler : MonoBehaviour
{

    [SerializeField]
    public Inventory inventario;
    public PanelIngredientes ingredientes;

    // Start is called before the first frame update
    public void Crafting()
    {
    
        if (ingredientes.item1ID == ingredientes.item2ID)
        {
            if (inventario.FindItemInInventory(ingredientes.item1ID) != null)
            {
               
                if (inventario.FindItemInInventory(ingredientes.item1ID).amount > 1)
                {
                   
                    
                        inventario.RemoveItem(ingredientes.item1ID);
                        inventario.RemoveItem(ingredientes.item2ID);
                        inventario.AddItem(ingredientes.itemID);

                    
                }
            }
            else
            {
                Debug.Log("No tengo suficientes materiales");
            }
        }
        else
        {
           if(inventario.FindItemInInventory(ingredientes.item1ID) != null && inventario.FindItemInInventory(ingredientes.item2ID) !=null )
            {
                inventario.RemoveItem(ingredientes.item1ID);
                inventario.RemoveItem(ingredientes.item2ID);
                inventario.AddItem(ingredientes.itemID);
            }
            else
            {
                Debug.Log("No tengo suficientes materiales");
            }

        }
    }
}
