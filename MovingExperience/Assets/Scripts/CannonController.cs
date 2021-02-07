using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    public GameObject head;
    private Rigidbody headRB;
    private Head h;
    public float firepower = 1000f;

    public Button aimLeft;
    public Button aimRight;
    public Button aimShoot;

    // Start is called before the first frame update
    void Start()
    {
        headRB = head.GetComponent<Rigidbody>();
        h = head.GetComponent<Head>();
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        aimLeft.gameObject.SetActive(false);
        aimRight.gameObject.SetActive(false);
        aimShoot.gameObject.SetActive(false);
    }

    public void AimLeft()
    {
        transform.Rotate(0f, -15f, 0f, Space.World);
    }

    public void AimRight()
    {
        transform.Rotate(0f, 15f, 0f, Space.World);
    }

    public void FireCannon()
    {
        headRB.AddForce(transform.forward * firepower);
        h.shot = true;
        aimLeft.gameObject.SetActive(false);
        aimRight.gameObject.SetActive(false);
        aimShoot.gameObject.SetActive(false);

    }
}
