using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArmController : MonoBehaviour
{

    public float speed = 50f;
    GameObject p;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Platform 6");
        this.transform.position = p.transform.position + new Vector3(0f, 3f, 0f);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
    }

    void FixedUpdate()
    {
        this.transform.RotateAround(p.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
