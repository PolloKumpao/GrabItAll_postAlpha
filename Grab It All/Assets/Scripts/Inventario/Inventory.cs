using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public GameMaster gm;

    [SerializeField]
    private DB database; //Referencia a database
    [SerializeField]
    private GameObject slotPrefab; //Referencia al prefab de slot
    [SerializeField]
    private Transform inventoryPanel; //Referencia al panel de inventario
    [SerializeField]
    public List<SlotInfo> slotInfoList; // Lista con la información de todos los slots
    [SerializeField]
    private int capacity; // capacidad de mi inventario

    private string jsonString; //Texto en formato Json que usaremos para guardar el inventario

    private void Start()
    {
        slotInfoList = new List<SlotInfo>();
       
        if (PlayerPrefs.HasKey("inventory"))
        {
            //recuperar inventario en el caso de que ya exista uno
            //LoadSavedInventory();
            LoadEmptyInventory();
        }
        else
        {
            //crear uno nuevo
            LoadEmptyInventory();
        }

       // gameObject.SetActive(false);
    }

    private void LoadEmptyInventory()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if (gm.slotInfoList.Count != 0)
        {
            Debug.Log("CargoInvent");
            slotInfoList = gm.slotInfoList;

            for (int i = 0; i < capacity; i++)
            {
                GameObject slot = Instantiate<GameObject>(slotPrefab, inventoryPanel);
                Slot newSlot = slotPrefab.GetComponent<Slot>();
                newSlot.SetUp(0);
                newSlot.database = database;
                newSlot.slotInfo = slotInfoList[0];
                newSlot.updateUI();


            }
           // FindSlot(slotInfo.id).updateUI();
        }
        else
        {
            for (int i = 0; i < capacity; i++)
            {
                GameObject slot = Instantiate<GameObject>(slotPrefab, inventoryPanel);
                Slot newSlot = slotPrefab.GetComponent<Slot>();
                newSlot.SetUp(i);
                newSlot.database = database;
                SlotInfo newSlotInfo = newSlot.slotInfo;
                slotInfoList.Add(newSlotInfo);
                newSlot.updateUI();
            }
        }
    }

   

    private void LoadSavedInventory()
    {
        jsonString = PlayerPrefs.GetString("inventory");
        InventoryWrapper inventoryWrapper = JsonUtility.FromJson<InventoryWrapper>(jsonString);
        this.slotInfoList = inventoryWrapper.slotInfoList;

        for (int i = 0; i < capacity; i++)
        {
            GameObject slot = Instantiate<GameObject>(slotPrefab, inventoryPanel);
            Slot newSlot = slotPrefab.GetComponent<Slot>();
            newSlot.SetUp(i);
            newSlot.database = database;
            newSlot.slotInfo = slotInfoList[i];
            newSlot.updateUI();
      
    
        }
    }

    //public void SwapSlots(int id_o, int id_d, Transform image_o, Transform image_d)
    //{
    //    // Cambiamos las imagenes
    //    image_o.SetParent(inventoryPanel.GetChild(id_d));
    //    image_d.SetParent(inventoryPanel.GetChild(id_o));
    //    image_o.localPosition = Vector3.zero;
    //    image_d.localPosition = Vector3.zero;

    //    // Comprobamos que son el mismo slot
    //    if (id_o != id_d)
    //    {
        
    //        SlotInfo origin = slotInfoList[id_o];
    //        SlotInfo destination = slotInfoList[id_d];

    //        slotInfoList[id_o] = destination;
    //        slotInfoList[id_o].id = id_o;

    //        slotInfoList[id_d] = origin;
    //        slotInfoList[id_d].id = id_d;

    //        Slot originSlot = inventoryPanel.GetChild(id_o).GetComponent<Slot>();
    //        originSlot.slotInfo = slotInfoList[id_o];
    //        Slot destinationSlot = inventoryPanel.GetChild(id_d).GetComponent<Slot>();
    //        destinationSlot.slotInfo = slotInfoList[id_d];

    //        originSlot.itemImage = image_d.GetComponent<Image>();
    //        destinationSlot.itemImage = image_o.GetComponent<Image>();

    //        originSlot.amountText = originSlot.itemImage.transform.GetChild(0).GetComponent<Text>();
    //        destinationSlot.amountText = destinationSlot.itemImage.transform.GetChild(0).GetComponent<Text>();


    //    }
    //}

    private SlotInfo FindSuitableSlot(int _itemId)
    {
        foreach (SlotInfo slotInfo in slotInfoList)
        {
            if (slotInfo.itemId == _itemId && slotInfo.amount < slotInfo.maxAmount && !slotInfo.isEmpty && database.FindItemInDataBase(_itemId).isStackable)
            {
               
                return slotInfo;
            }

        }
        foreach (SlotInfo slotInfo in slotInfoList)
        {
            if (slotInfo.isEmpty)
            {
                
                slotInfo.EmptySlot();
                return slotInfo;
            }
        }
        return null;

    }

    public SlotInfo FindItemInInventory(int _itemId)
    {
        foreach (SlotInfo slotInfo in slotInfoList)
        {
            if (slotInfo.itemId == _itemId && !slotInfo.isEmpty)
            {
                return slotInfo;
            }
        }
        return null;
    }

    private Slot FindSlot (int id)
    {
        return inventoryPanel.GetChild(id).GetComponent<Slot>();
    }
    public void AddItem(int itemId)
    {
        Objeto item = database.FindItemInDataBase(itemId); //Buscar en la base de datos
        if (item != null)
        {
            
            SlotInfo slotInfo = FindSuitableSlot(itemId); //Encontrar donde guardar el item;
            if (slotInfo != null)
            {
                FindSlot(slotInfo.id).slotInfo.amount++;
                FindSlot(slotInfo.id ).slotInfo.itemId = itemId;
                FindSlot(slotInfo.id).slotInfo.isEmpty = false;
                FindSlot(slotInfo.id).updateUI();



                slotInfo.amount++;
                slotInfo.itemId = itemId;
                slotInfo.isEmpty = false;


            }
            else
            {
                Debug.Log("No hay hueco");
            }
        }
    }

    public void RemoveItem(int itemId)
    {
        SlotInfo slotInfo = FindItemInInventory(itemId);
        if (slotInfo != null)
        {
            if (slotInfo.amount == 1)
            {
                slotInfo.EmptySlot();
            }
            else
            {
                slotInfo.amount--;
            }
            FindSlot(slotInfo.id).updateUI();
        }
    }

    public void SaveInventory()
    {
        InventoryWrapper inventoryWrapper = new InventoryWrapper();
        inventoryWrapper.slotInfoList = this.slotInfoList;
        jsonString = JsonUtility.ToJson(inventoryWrapper);
        PlayerPrefs.SetString("inventory", jsonString);
    }
    private struct InventoryWrapper
        {
        public List<SlotInfo> slotInfoList;
        }

    [ContextMenu("Test Add - itemId = 6")]
    public void TestAdd()
    {
        AddItem(6);
    }
    [ContextMenu("test Remove - itemId = 2")]
    public void TestRemove()
    {
        RemoveItem(2);

    }
    [ContextMenu("test Save")]
    public void TestSave()
    {
        SaveInventory();
    }
}
 