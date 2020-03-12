using System.Collections;
using System.Collections.Generic;

using UnityEngine;
[CreateAssetMenu(menuName = "DataBase")]
public class DB : ScriptableObject
{
    public List<Objeto> items = new List<Objeto>();

    public Objeto FindItemInDataBase(int id)
    {
        foreach (Objeto item in items)
        {
            if (item.id == id)
            {
               return item;
            }
        }
        return null;
    }

}
[System.Serializable]
public class Objeto
{
    public bool isStackable;
    public Vector2 scrollPos;
    public int id;
    public string name;
    public int cost;
    public bool dropeable;
    public string description; 
    public enum  ItemType  { CONSUMABLE, DROPEABLE, CLOTH};
    public ItemType tipo;
    public Sprite itemImage;
    public int ingrediente1;
    public int ingrediente2;
}

