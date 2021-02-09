using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{

    public bool freeze;
    private Rigidbody rb;
    GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        freeze = false;
        rb = this.GetComponent<Rigidbody>();
        p = GameObject.Find("Platform 2");
        this.transform.position = p.transform.position + new Vector3(9f, 2.5f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(this.transform.rotation.eulerAngles.z > 70)
        {
            this.transform.position = p.transform.position + new Vector3(9f, 2.5f, 0f);
            this.transform.rotation = Quaternion.Euler(Vector3.zero);
            rb.velocity = Vector3.zero;
        }

        if (freeze)
        {
            rb.isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SeeSaw")
        {
            freeze = true;
        }
    }
}
