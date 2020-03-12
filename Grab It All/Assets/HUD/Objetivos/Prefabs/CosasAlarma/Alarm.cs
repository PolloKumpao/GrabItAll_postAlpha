using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public bool on_off;
    public bool active;
    GameObject player;
    PlayerStats playerStats;
    // Start is called before the first frame update
    void Start()
    {
        on_off = false;
        active = true;
        player = GameObject.Find("Player2.0");
        playerStats = player.GetComponents<PlayerStats>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (active && on_off)
        {
            playerStats.detectionLevel = 80;
        }
        
    }
    public void setOn()
    {
        on_off = true;
    }
    public void hack()
    {
        active = false;
    }
    
}
