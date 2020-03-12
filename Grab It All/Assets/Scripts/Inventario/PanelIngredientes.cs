using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PanelIngredientes : MonoBehaviour
{
    public DB database;
    public int itemID;
    public Image image1;
    public Image image2;
    public Image imageResultante;
    private int lastID;
    public int item1ID;
    public int item2ID;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(lastID!=itemID)
        {
            lastID = itemID;
            item1ID = database.FindItemInDataBase(itemID).ingrediente1;
            item2ID = database.FindItemInDataBase(itemID).ingrediente2;
            image1.sprite = database.FindItemInDataBase(item1ID).itemImage;
            image2.sprite = database.FindItemInDataBase(item2ID).itemImage;
            imageResultante.sprite = database.FindItemInDataBase(itemID).itemImage;
           
            Debug.Log("Imagen actualizada");

        }
      
        
    }
}
