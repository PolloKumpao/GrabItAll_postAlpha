using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    //futuro manager para la tienda
    void Start()
    {
        PlayerPrefs.SetFloat("speed", 12f);
        PlayerPrefs.SetFloat("stealSpeed", 8f);
        PlayerPrefs.SetFloat("detectionSightRange", 8f);
        PlayerPrefs.SetFloat("detectionNoiseRange", 8f);
        PlayerPrefs.SetFloat("detectionLevel", 0f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
