using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RecipeSelect : MonoBehaviour , IPointerDownHandler, IPointerClickHandler
{
    public SlotReceta SlotReceta;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        SlotReceta.click();
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
