using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class SlotReceta : MonoBehaviour
{
    private int itemID;
    public DB database;
    public Image itemImage;
    public SlotInfo slotInfo;
    public PanelIngredientes panelingredientes;
    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click()
    {
        itemID = slotInfo.itemId;
        panelingredientes.itemID = itemID;
    }
}
