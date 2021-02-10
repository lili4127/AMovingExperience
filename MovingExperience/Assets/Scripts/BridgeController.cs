using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{
    
    public float speed = 30f;

    //spin the bridge relative to the z axis at a designated speed
    void FixedUpdate()
    {
        this.transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
