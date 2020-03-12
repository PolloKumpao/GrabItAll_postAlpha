using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthBar : MonoBehaviour
{
    private float nivelAlerta;
    public PlayerStats stats;
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Barra");
        
        
    }

    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }


    // Update is called once per frame
    void Update()
    {
        nivelAlerta = stats.detectionLevel / 100;
        SetSize(nivelAlerta);
    }
}
