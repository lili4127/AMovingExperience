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
    GameObject p;

    //Cannon Variables to interact with the Head on platform 1
    public GameObject cannon;
    public bool shot;
    public Button aimLeft;
    public Button aimRight;
    public Button aimShoot;

    public HealthBar healthBar;

    //First person camera
    private Transform FPCam;

     //Set current platform to starting platform of game and get camera attached to head
    private void Awake()
    {
        currentPlatform = "Platform 1";
        FPCam = this.transform.GetChild(0);
    }

     //Set ball's initial position on platform one, enable the gyroscope, and
     //set booleans so that head knows it is alone and not on cannon so it can move
    void Start()
    {
        noParent = true;
        rb = this.GetComponent<Rigidbody>();
        EnableGyro();

        shot = true;
        aimLeft.gameObject.SetActive(false);
        aimRight.gameObject.SetActive(false);
        aimShoot.gameObject.SetActive(false);

        p = GameObject.Find(currentPlatform);

        this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
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

        //if shot is false ball is currently on cannon
        if (!shot)
        {
            this.transform.position = cannon.transform.position + Vector3.up;
        }

        //if head falls below -100 (falling down from a platform) reset its velocity to 0
        //and place it above the center of its last saved platform. Lose 5 health for falling off.
        if (this.transform.position.y < -100)
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

    //if head collides with different tags perform different functions
    private void OnCollisionEnter(Collision collision)
    {
        //if head collides with a platform update current platform to be this last know platform it collided with
        if (collision.gameObject.tag == "Platform")
        {
            currentPlatform = collision.gameObject.name;
        }

        //if head collides with cannon freeze its movement above cannon and activate cannon UI
        if (collision.gameObject.tag == "Cannon")
        {
            shot = false;
            this.transform.position = cannon.transform.position + Vector3.up;
            aimLeft.gameObject.SetActive(true);
            aimRight.gameObject.SetActive(true);
            aimShoot.gameObject.SetActive(true);
        }

        //if head collides with ground reset its velocity to 0 and place it back onto its last known platform
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            p = GameObject.Find(currentPlatform);
            this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
            healthBar.LoseHealth(5);
        }
    }
}
