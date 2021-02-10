using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//answers.unity.com/questions/620146/how-to-gradually-grow-and-shrink-an-object.html
public class RingController : MonoBehaviour
{
    //scaling variables
    float scaleRate = 1.0f;
    float minScale = 0.5f;
    float maxScale = 10f;
    public float speed = 15f;

    public GameObject player;
    Rigidbody rb;
    Leg leg;

    //get player's rigidbody and leg
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        leg = player.GetComponent<Leg>();
    }

    //scale the rings every frame
    void Update()
    {
        Scale();
    }

    //scale ring according to scale rate and speed. Make sure scale is called relative to time
    void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate * Time.deltaTime * speed;
    }

    //scale the ring larger or smaller based on its current size
    void Scale()
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate();
    }

    //if ring collides with any part of player reset player's velocity, remove health, and push player back
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Head" || other.gameObject.tag == "Body" || other.gameObject.tag == "Leg")
        {
            leg.healthBar.LoseHealth(5);
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.right * 10);
        }
    }
}
