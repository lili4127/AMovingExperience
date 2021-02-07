using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public GameObject pHead;
    private Rigidbody rb;
    public GameObject pLeg;
    public bool noParent;
    Gyroscope gyro;

    public string currentPlatform;
    GameObject p;

    public HealthBar healthBar;

    private void Awake()
    {
        currentPlatform = "Platform 3";
        rb = this.GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        noParent = true;
        EnableGyro();

        p = GameObject.Find(currentPlatform);
        this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //set object's rotation equal to device rotation
        transform.rotation = GyroToUnity(gyro.attitude);

        if (transform.childCount > 0 && noParent)
        {
            float moveHorizontal = GyroToUnity(gyro.attitude).x;
            float moveVertical = GyroToUnity(gyro.attitude).y;
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            transform.rotation = Quaternion.identity;
            transform.Translate(movement);

            if (this.transform.position.y < -100)
            {
                rb.velocity = Vector3.zero;
                p = GameObject.Find(currentPlatform);
                this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
                healthBar.LoseHealth(5);
            }
        }

        if (!noParent)
        {
            this.transform.position = pLeg.transform.position + Vector3.up;
            this.currentPlatform = pLeg.GetComponent<Leg>().currentPlatform;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Head")
        {
            pHead.GetComponent<Head>().noParent = false;
            pHead.transform.parent = this.transform;
            pHead.transform.position = this.transform.position + Vector3.up;
        }

        if (collision.gameObject.tag == "Platform")
        {
            currentPlatform = collision.gameObject.name;
        }

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
