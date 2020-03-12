using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObjetivo : MonoBehaviour
{
    public objetivosController controller;
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
            if(controller.numeroObjetivo == 9)
            {
                controller.numeroObjetivo++;
            }
        }
    }
}
