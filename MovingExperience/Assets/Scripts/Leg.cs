using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//jumping code inspired by www.youtube.com/watch?v=vdOFUFMiPDU
public class Leg : MonoBehaviour
{
    public GameObject pBody;
    public bool noParent;
    public float jumpForce;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private CapsuleCollider col;
    private float width;
    public string currentPlatform;
    Gyroscope gyro;


    // Start is called before the first frame update
    void Start()
    {
        noParent = true;
        rb = this.GetComponent<Rigidbody>();
        col = this.GetComponent<CapsuleCollider>();
        jumpForce = 20f;
        width = (float)Screen.width / 2.0f;
        currentPlatform = "Platform 5";
        EnableGyro();
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

            if (isGrounded() && Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                //left side of screen
                if (t.phase == TouchPhase.Ended && (int)t.position.x < (int)(Screen.height / 2f))
                {
                    rb.AddForce(Vector3.up * 2 * jumpForce, ForceMode.Impulse);
                    rb.AddForce(Vector3.left * jumpForce, ForceMode.Impulse);

                }

                //right side of screen
                if (t.phase == TouchPhase.Ended && (int)t.position.x > (int)(Screen.height / 2f))
                {
                    rb.AddForce(Vector3.up * 2 * jumpForce, ForceMode.Impulse);
                    rb.AddForce(Vector3.right * jumpForce, ForceMode.Impulse);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Body")
        {
            pBody.GetComponent<Body>().noParent = false;
            pBody.transform.parent = this.transform;
            pBody.transform.position = this.transform.position + Vector3.up;
        }

        if (collision.gameObject.tag == "Platform")
        {
            currentPlatform = collision.gameObject.name;
        }

        if (collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector3.zero;
            GameObject p = GameObject.Find(currentPlatform);
            this.transform.position = p.transform.position + new Vector3(0f, 10f, 0f);
        }
    }

    //check to see if player is on the ground so that jump is limited to one
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
