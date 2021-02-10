using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{

    public bool freeze;
    private Rigidbody rb;
    GameObject p;

    //set seesaw's original position on platform 2
    void Start()
    {
        freeze = false;
        rb = this.GetComponent<Rigidbody>();
        p = GameObject.Find("Platform 2");
        this.transform.position = p.transform.position + new Vector3(9f, 2.5f, 0f);
    }

    void FixedUpdate()
    {
        //if player tried to cross without moving box and see saw has leaned reset it
        if (this.transform.rotation.eulerAngles.z > 70)
        {
            this.transform.position = p.transform.position + new Vector3(9f, 2.5f, 0f);
            this.transform.rotation = Quaternion.Euler(Vector3.zero);
            rb.velocity = Vector3.zero;
        }

        //if player has rolled movable onto seesaw make it is kinematic so player can cross
        if (freeze)
        {
            rb.isKinematic = true;
        }
    }

    //if movable object has collided with seesaw player has rolled it on and see saw can freeze
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SeeSaw")
        {
            freeze = true;
        }
    }
}
