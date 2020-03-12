using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance ;
    
    public int numeroObjetivo;
    public Vector3 playerPos;
    // public PlayerStats playerStats;
    public  List<SlotInfo> slotInfoList;
    public Inventory inventario;

    //[SerializeField]
    //public objetivosController Rcontroller;
    //[SerializeField]
    //public Transform RplayerTransform;
    //[SerializeField]
    //public PlayerStats RplayerStats;
    //[SerializeField]
    //public Inventory Rinventario;
    // Start is called before the first frame update
   
   void Awake()
    {
        if(instance == null )
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {


            Destroy(gameObject);
        }
    }
    
    //public void reload()
    //{
    //    Rcontroller = controller;
    //    Rinventario = inventario;
    //    RplayerStats = playerStats;
    //    RplayerTransform = playerTransform;
       
    //}
    //public void checkPoint(objetivosController c, Transform t, PlayerStats p, Inventory i )
    //{
    //    controller = c;
    //    playerTransform = t;
    //    playerStats = p;
    //    inventario = i;

    //}
}
