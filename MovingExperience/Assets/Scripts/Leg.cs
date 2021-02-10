using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//jumping code inspired by www.youtube.com/watch?v=vdOFUFMiPDU
public class Leg : MonoBehaviour
{
    //player variables
    public GameObject pBody;
    public bool noParent;
    public float jumpForce;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private CapsuleCollider col;
    private float width;
    Gyroscope gyro;

    public string currentPlatform;
    GameObject p;
    
    public HealthBar healthBar;

    //Leg will always be located on Platform 5. Get its rigidbody for movement and capsule collider for jumps
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        col = this.GetComponent<CapsuleCollider>();
        currentPlatform = "Platform 5";
    }


    //Set original position above platform 5 and variables for jumping and touching the screen
    void Start()
    {
        noParent = true;
        jumpForce = 15f;
        width = (float)Screen.width / 2.0f;
        EnableGyro();

        p = GameObject.Find(currentPlatform);
        this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
    }

    void FixedUpdate()
    {
        //set object's rotation equal to device rotation
        transform.rotation = GyroToUnity(gyro.attitude);

        //if leg has a child and no parent then the body is attached and it should be moving
        //same methodology behind body movement
        if (transform.childCount > 0 && noParent)
        {
            float moveHorizontal = GyroToUnity(gyro.attitude).x;
            float moveVertical = GyroToUnity(gyro.attitude).y;
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            transform.rotation = Quaternion.identity;
            transform.Translate(movement);

            //if leg falls below -100 (falling down from a platform) reset its velocity to 0
            //and place it above the center of its last saved platform. Lose 5 health for falling off.
            if (this.transform.position.y < -100)
            {
                rb.velocity = Vector3.zero;
                p = GameObject.Find(currentPlatform);
                this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
                healthBar.LoseHealth(5);
            }

            //if leg is touching the ground and the screen was touched then jump
            //if player taps fast two touches can be registered which will double the forces creating
            //a higher jump. Similarly if player is already sliding in a direction and taps, the force
            //will be added to the translation force resulting in a longer jump
            if (isGrounded() && Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                //left side of screen touch adds force up and to the left
                if (t.phase == TouchPhase.Ended && (int)t.position.x < (int)(Screen.height / 2f))
                {
                    rb.AddForce((Vector3.up * 2.5f) * jumpForce, ForceMode.Impulse);
                    rb.AddForce(Vector3.left * jumpForce, ForceMode.Impulse);
                }

                //right side of screen touch adds force up and to the right
                if (t.phase == TouchPhase.Ended && (int)t.position.x > (int)(Screen.height / 2f))
                {
                    rb.AddForce((Vector3.up * 2.5f) * jumpForce, ForceMode.Impulse);
                    rb.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
                }
            }
        }

        //call win game if players current platform is registered as platform 8
        if(currentPlatform == "Platform 8")
        {
            FindObjectOfType<GameManager>().WinGame();
        }
    }

    //if leg collides with different tags perform different functions
    private void OnCollisionEnter(Collision collision)
    {
        //if body and leg collide combine them to form full player
        if (collision.gameObject.tag == "Body")
        {
            pBody.GetComponent<Body>().noParent = false;
            pBody.transform.parent = this.transform;
            pBody.transform.position = this.transform.position + Vector3.up;
        }

        //if leg collides with a platform update current platform to be this last know platform it collided with
        if (collision.gameObject.tag == "Platform")
        {
            currentPlatform = collision.gameObject.name;
        }

        //if leg collides with ground reset its velocity to 0 and place it back onto its last known platform
        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            p = GameObject.Find(currentPlatform);
            this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
            healthBar.LoseHealth(5);
        }
    }

    //check to see if player is on the ground so that player cannot jump off air
    private bool isGrounded()
    {
        //check that bottom of collider is touching a ground layer
        return Physics.CheckCapsule(col.bounds.center,
            new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z),
            col.radius * 0.9f, groundLayer);
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
