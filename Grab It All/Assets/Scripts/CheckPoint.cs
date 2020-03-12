using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameMaster gm;
    //public objetivosController controller;
    //public Transform playerTransform;
    //public PlayerStats playerStats;
    //public Inventory inventario;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("CheckPoint");
        gm.numeroObjetivo = GameObject.FindGameObjectWithTag("Objetivos").GetComponent<objetivosController>().numeroObjetivo;
        gm.playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        //gm.playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        gm.slotInfoList = GameObject.FindGameObjectWithTag("Inventario").GetComponent<Inventory>().slotInfoList;
    }
}
