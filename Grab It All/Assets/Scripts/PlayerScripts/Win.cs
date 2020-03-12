using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public int ID;
    bool canExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "META")
        {
            //recorrer inventario comprobando el id
            //poner variable true
            if (canExit)
            {
                //final nivel
            }
        }
    }
}
