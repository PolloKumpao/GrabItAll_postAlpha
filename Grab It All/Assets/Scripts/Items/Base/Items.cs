using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor.IMGUI;




[System.Serializable]
public class Items :MonoBehaviour
{
    protected PlayerStats stats;
    protected bool Droped = false;
    public const string _keyR = "Fire2";
    public const string _keyF = "Fire1";
    public const string _keyQ = "Fire3";

    public int id;
    public string ItemName;
    public string description;
    public string value;
    public bool isStackable;
    [SerializeField]
    protected Inventory inventory;
    [SerializeField]
    protected GameObject PanelText;

    [SerializeField]
    protected GameObject PanelLoadBar;

    [SerializeField]
    protected TMPro.TextMeshProUGUI TextToUse;

    [SerializeField]
    protected Image BarLoad;

    [SerializeField]
    protected ScriptableItemBase itemBase;
    
    public bool End;
    
    public virtual void GetOrInteract()
    {
        if (itemBase.Dropable)
           Drop();
        else
            Interact();
    }
    public virtual void Interact()
    {
    }
    public virtual void Stoped()
    {
        if (!(BarLoad.fillAmount >= 1.0f))
        {
            BarLoad.fillAmount = 0.0f;
        }
    }
    public virtual void Craf()
    {

    }

    public virtual void Drop()
    {
        Debug.Log("Add");
        inventory.AddItem(id);
    }


    public virtual void GetAmount()
    {

    }


}
