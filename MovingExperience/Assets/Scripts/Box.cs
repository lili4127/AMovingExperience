using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public GameObject seesaw;
    Rigidbody rb;
    private Transform originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        originalPosition = transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SeeSaw")
        {
            Debug.Log("On the seesaw!");
            rb.mass = 50;
        }

        if (collision.gameObject.tag == "Ground")
        {
            this.transform.position = originalPosition.position;
        }
    }

}
