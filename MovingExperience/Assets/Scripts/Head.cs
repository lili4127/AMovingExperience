using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//gyro code inspired from www.youtube.com/watch?v=P5JxTfCAOXo&list=PL4TRmp0diKHJNYR_0bARFa7Jj1lHzHIyR
public class Head : MonoBehaviour
{
    //General Movement
    public float speed = 50f;
    public bool noParent;
    public GameObject pBody;
    private Rigidbody rb;
    Gyroscope gyro;
    public string currentPlatform;

    //Cannon Variables
    public GameObject cannon;
    public bool shot;
    private Transform FPS;
    public Button aimLeft;
    public Button aimRight;
    public Button aimShoot;

    private void Awake()
    {
        currentPlatform = "Platform 1";
        FPS = this.transform.GetChild(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        noParent = true;
        rb = this.GetComponent<Rigidbody>();
        EnableGyro();
        shot = true;
        aimLeft.gameObject.SetActive(false);
        aimRight.gameObject.SetActive(false);
        aimShoot.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        //set object's rotation equal to device rotation
        transform.rotation = GyroToUnity(gyro.attitude);

        //update objects location as long as it has no parents (not yet attached to body)
        if (noParent)
        {
            float moveHorizontal = GyroToUnity(gyro.attitude).x;
            float moveVertical = GyroToUnity(gyro.attitude).y;
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            rb.AddForce((movement * speed * Time.deltaTime) * 10f);
        }

        //if head is attached to body, make it stay on top of body
        if (!noParent)
        {
            this.transform.position = pBody.transform.position + Vector3.up;
            this.currentPlatform = pBody.GetComponent<Body>().currentPlatform;
        }

        if (!shot)
        {
            this.transform.position = cannon.transform.position + Vector3.up;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            currentPlatform = collision.gameObject.name;
        }

        if (collision.gameObject.tag == "Cannon")
        {
            shot = false;
            this.transform.position = cannon.transform.position + Vector3.up;
            aimLeft.gameObject.SetActive(true);
            aimRight.gameObject.SetActive(true);
            aimShoot.gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            GameObject p = GameObject.Find(currentPlatform);
            this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
        }
    }
}
