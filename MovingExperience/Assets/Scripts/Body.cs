using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    //Movement variables
    public GameObject pHead;
    private Rigidbody rb;
    public GameObject pLeg;
    public bool noParent;
    Gyroscope gyro;

    public string currentPlatform;
    GameObject p;

    public HealthBar healthBar;

    //Body will always be located on Platform 3. Get its rigidbody for movement
    private void Awake()
    {
        currentPlatform = "Platform 3";
        rb = this.GetComponent<Rigidbody>();
    }

    //Set original position above platform 3
    void Start()
    {
        noParent = true;
        EnableGyro();

        p = GameObject.Find(currentPlatform);
        this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
    }

    void FixedUpdate()
    {
        //set object's rotation equal to device rotation
        transform.rotation = GyroToUnity(gyro.attitude);

        //if body has a child and no parent then the head is attached and it should be moving
        //same methodology behind head movement except using translate to slide instead of roll
        if (transform.childCount > 0 && noParent)
        {
            float moveHorizontal = GyroToUnity(gyro.attitude).x;
            float moveVertical = GyroToUnity(gyro.attitude).y;
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            transform.rotation = Quaternion.identity;
            transform.Translate(movement);

            //if body falls below -100 (falling down from a platform) reset its velocity to 0
            //and place it above the center of its last saved platform. Lose 5 health for falling off.
            if (this.transform.position.y < -100)
            {
                rb.velocity = Vector3.zero;
                p = GameObject.Find(currentPlatform);
                this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
                healthBar.LoseHealth(5);
            }
        }

        //if body has a parent it is attached to leg and should maintain its position on top of the leg
        if (!noParent)
        {
            this.transform.position = pLeg.transform.position + Vector3.up;
            this.currentPlatform = pLeg.GetComponent<Leg>().currentPlatform;
        }
    }

    //if body collides with different tags perform different functions
    private void OnCollisionEnter(Collision collision)
    {
        //if body and head collide combine them to form body player
        if(collision.gameObject.tag == "Head")
        {
            pHead.GetComponent<Head>().noParent = false;
            pHead.transform.parent = this.transform;
            pHead.transform.position = this.transform.position + Vector3.up;
        }

        //if body collides with a platform update current platform to be this last know platform it collided with
        if (collision.gameObject.tag == "Platform")
        {
            currentPlatform = collision.gameObject.name;
        }

        //if body collides with ground reset its velocity to 0 and place it back onto its last known platform
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            p = GameObject.Find(currentPlatform);
            this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
            healthBar.LoseHealth(5);
        }
    }

    //left to right handed coordinate system
    private static Quaternion GyroToUnity(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    //make sure device supports gyroscope and enable it
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true;
        }

        return false;
    }
}
