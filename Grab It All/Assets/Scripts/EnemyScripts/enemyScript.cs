using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public bool pickable;
    public bool alive = true;
    public int itemEnemyID;

    public void die()
    {
        alive = false;
        pickable = true;
    }
    public void pick(GameObject player)
    {
        transform.SetParent(player.transform);
    }

    public void drop(GameObject player)
    {
        transform.SetParent(null);
    }
}
