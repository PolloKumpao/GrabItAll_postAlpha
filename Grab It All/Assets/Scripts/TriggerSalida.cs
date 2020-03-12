using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSalida : MonoBehaviour
{
   public objetivosController controller;
   public GameObject objetoWin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(controller.numeroObjetivo == 16)
            {
                //objetoWin.SetActive(true);
            }
        }
    }
}
