using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//answers.unity.com/questions/620146/how-to-gradually-grow-and-shrink-an-object.html
public class RingController : MonoBehaviour
{
    float scaleRate = 1.0f;
    float minScale = 0.5f;
    float maxScale = 10f;
    public float speed = 15f;

    public GameObject player;
    Rigidbody rb;
    Leg leg;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        leg = player.GetComponent<Leg>();
    }

    // Update is called once per frame
    void Update()
    {
        Scale();
    }

    void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate * Time.deltaTime * speed;
    }

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
