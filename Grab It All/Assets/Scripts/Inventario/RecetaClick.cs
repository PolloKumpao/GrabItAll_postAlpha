using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RecetaClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject item1;
    [SerializeField]
    private GameObject item2;
    [SerializeField]
    public Image image1;
    [SerializeField]
    public GameObject image2;

    private Image myImage1;
    private Image myImage2;

    public void OnPointerDown(PointerEventData eventData)
    {
     
    }

    // Start is called before the first frame update
    void Start()
    {
        myImage1 = item1.GetComponentInChildren<Image>();
        myImage2 = item2.GetComponentInChildren<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
