using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour
{
    public GameObject p;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    //the angle to complete in deltaTime
    public int speed = 60;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        p.transform.RotateAround(this.transform.position, Vector3.forward, speed * Time.deltaTime);
        p.transform.rotation = Quaternion.identity;

        p2.transform.RotateAround(this.transform.position, Vector3.forward, speed * Time.deltaTime);
        p2.transform.rotation = Quaternion.identity;

        p3.transform.RotateAround(this.transform.position, Vector3.forward, speed * Time.deltaTime);
        p3.transform.rotation = Quaternion.identity;

        p4.transform.RotateAround(this.transform.position, Vector3.forward, speed * Time.deltaTime);
        p4.transform.rotation = Quaternion.identity;
    }
}

