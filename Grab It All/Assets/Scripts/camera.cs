using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float maxX;
    public float minX;

    public float maxZ;
    public float minZ;
    // Use this for initialization
    void Start()
    {
        transform.Rotate(new Vector3(1, 0, 0), 90f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            // Always Update to Exactly Targets Position + Offset
            transform.position = new Vector3(
                Mathf.Clamp(target.transform.position.x + offset.x,minX,maxX),
                target.transform.position.y + offset.y,
                Mathf.Clamp(target.transform.position.z + offset.z,minZ,maxZ));
        }
    }
}
