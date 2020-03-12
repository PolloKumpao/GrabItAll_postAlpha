using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarm : MonoBehaviour
{
    public objetivosController controller;
    public patrol[] guards;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("in");

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("f");
                if (controller.numeroObjetivo == 11)
                {
                    controller.numeroObjetivo++;
                }
                for (int i = 0; i < guards.Length; ++i)
                {
                    guards[i].alarmOn = true;
                }
            }
        }
    }
}