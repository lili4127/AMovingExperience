using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArmController : MonoBehaviour
{

    public float speed = 50f;
    GameObject p;

    //set original position and rotation on platform 6
    void Start()
    {
        p = GameObject.Find("Platform 6");
        this.transform.position = p.transform.position + new Vector3(0f, 3f, 0f);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
    }

    //rotate arm relative to y axis so it spins around to knock player off
    void FixedUpdate()
    {
        this.transform.RotateAround(p.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
