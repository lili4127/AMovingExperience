using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollable : MonoBehaviour
{
    GameObject p;
    Rigidbody rb;

    //set objects initial position on Platform 2
    void Start()
    {
        p = GameObject.Find("Platform 2");
        this.transform.position = p.transform.position + new Vector3(0f, 3f, -5f);
        rb = this.GetComponent<Rigidbody>();
    }

    //if box is accidentally rolled off platform bring it back
    void Update()
    {
        if (this.transform.position.y < -100)
        {
            rb.velocity = Vector3.zero;
            p = GameObject.Find("Platform 2");
            this.transform.position = p.transform.position + new Vector3(0f, 3f, -5f);
        }
    }

    //if box is accidentally rolled off platform and hits the ground bring it back
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            p = GameObject.Find("Platform 2");
            this.transform.position = p.transform.position + new Vector3(0f, 3f, -5f);
        }
    }
}
