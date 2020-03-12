using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objetivosController : MonoBehaviour
{
    public XmlLoader ListaLoaded;
    public Objetivos objetivoActual;
    public int numeroObjetivo;
    public Text textoObjetivo;
    public Text textoComplementario;
    public PlayerStats playerStats;
    public Inventory inventarioPlayer;
    public Canvas Inventario_UI;
    public GameObject Win;
    public Canvas Craft_UI;
    public Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        numeroObjetivo = 0;
        ListaLoaded = GetComponent<XmlLoader>();
      

     
       
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = playerStats.GetComponentInParent<Transform>().position;
        setObjetivo();
        checkObjetivo();
        if (numeroObjetivo == 17)
        {
            Win.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<movement>().enabled = false;
        }
        else
        {
            Win.SetActive(false);
        }


    }
    void setObjetivo()
    {
        textoComplementario.enabled = true;
        switch (ListaLoaded.ListaObjetivos[numeroObjetivo].tipo)
        {
            case "Dinero":
                textoObjetivo.text = ListaLoaded.ListaObjetivos[numeroObjetivo].mensaje;
                textoComplementario.enabled = true;
                textoComplementario.text = ListaLoaded.ListaObjetivos[numeroObjetivo].mensaje2.ToString();
                break;
            case "Posicion":
                textoObjetivo.text = ListaLoaded.ListaObjetivos[numeroObjetivo].mensaje;
                //textoComplementario.enabled = false;
                textoComplementario.text = "";
                break;
            case "Cantidad":
                textoComplementario.enabled = true;
                textoObjetivo.text = ListaLoaded.ListaObjetivos[numeroObjetivo].mensaje;
                if (inventarioPlayer.FindItemInInventory(ListaLoaded.ListaObjetivos[numeroObjetivo].getObjetoaConseguir()) != null)
                {
                    
                    textoComplementario.text = inventarioPlayer.FindItemInInventory(ListaLoaded.ListaObjetivos[numeroObjetivo].getObjetoaConseguir()).amount + " / " + ListaLoaded.ListaObjetivos[numeroObjetivo].getCantidad().ToString();
                }
                else
                {
                  
                    textoComplementario.text = "0" + " / " + ListaLoaded.ListaObjetivos[numeroObjetivo].getCantidad().ToString();
                }
                break;
            case "Clave":
                //textoComplementario.enabled = false;
                textoComplementario.text = "";
                textoObjetivo.text = ListaLoaded.ListaObjetivos[numeroObjetivo].mensaje;
                break;
            case "Menus":
                textoComplementario.text = ListaLoaded.ListaObjetivos[numeroObjetivo].mensaje2;
                textoComplementario.enabled = true;
                textoObjetivo.text = ListaLoaded.ListaObjetivos[numeroObjetivo].mensaje;
                break;
        }

    }
    void checkObjetivo()
    {
        switch (ListaLoaded.ListaObjetivos[numeroObjetivo].tipo)
        {
            case "Dinero":
                    if(playerStats.totalLoot>= ListaLoaded.ListaObjetivos[numeroObjetivo].getCantidad())
                {
                    numeroObjetivo++;
                }
                break;
            case "Posicion":
                if (playerPos.x < ListaLoaded.ListaObjetivos[numeroObjetivo].getmaxPos().x && playerPos.z < ListaLoaded.ListaObjetivos[numeroObjetivo].getmaxPos().y && playerPos.x > ListaLoaded.ListaObjetivos[numeroObjetivo].getminPos().x && playerPos.z > ListaLoaded.ListaObjetivos[numeroObjetivo].getminPos().y)
                {
                    numeroObjetivo++;
                }
                
                break;
            case "Cantidad":
                if (inventarioPlayer.FindItemInInventory(ListaLoaded.ListaObjetivos[numeroObjetivo].getObjetoaConseguir()) != null)
                {
                    Debug.Log("no es null");
                    if (inventarioPlayer.FindItemInInventory(ListaLoaded.ListaObjetivos[numeroObjetivo].getObjetoaConseguir()).amount >= ListaLoaded.ListaObjetivos[numeroObjetivo].getCantidad())
                    {
                        numeroObjetivo++;
                    }
                }
                break;
            case "Clave":
                if (inventarioPlayer.FindItemInInventory(ListaLoaded.ListaObjetivos[numeroObjetivo].getObjetoaConseguir()) != null)
                {
                    numeroObjetivo++;
                }
                    break;
            case "Menus":
                if (ListaLoaded.ListaObjetivos[numeroObjetivo].getInput() == "Inventario")
                {
                    if (Inventario_UI.enabled == true)
                    {
                        numeroObjetivo++;
                    }
                }
                else if (ListaLoaded.ListaObjetivos[numeroObjetivo].getInput() == "Craft")
                {
                    if (Craft_UI.enabled == true)
                    {
                        numeroObjetivo++;
                    }
                }
                break;
        }


    }
}
