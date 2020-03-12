using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragTry : MonoBehaviour , IPointerDownHandler, IPointerClickHandler
{
    public DB database;
    private PlayerEquiped player;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Click");
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
          //  Debug.Log(GetComponentInParent<Slot>().slotInfo.itemId);
            if (database.FindItemInDataBase(GetComponentInParent<Slot>().slotInfo.itemId).dropeable)
            {
                player.Equipar(database.FindItemInDataBase(GetComponentInParent<Slot>().slotInfo.itemId).id);
                Debug.Log("ESdropeable");
            }
            else
            {
                
              
                Debug.Log("NoDropeable");
            }
            
           // if(GetComponentInParent<Slot>().slotInfo.id;
           
            Debug.Log("double click");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerEquiped>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
