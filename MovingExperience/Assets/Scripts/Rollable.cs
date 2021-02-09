using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollable : MonoBehaviour
{
    GameObject p;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Platform 2");
        this.transform.position = p.transform.position + new Vector3(0f, 3f, -8f);
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -100)
        {
            rb.velocity = Vector3.zero;
            p = GameObject.Find("Platform 2");
            this.transform.position = p.transform.position + new Vector3(0f, 3f, -8f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            p = GameObject.Find("Platform 2");
            this.transform.position = p.transform.position + new Vector3(0f, 10f, -8f);
        }
    }
}
