using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonController : MonoBehaviour
{
    //variables for firing the cannon and displaying UI
    public GameObject head;
    private Rigidbody headRB;
    private Head h;
    public float firepower = 1000f;

    public Button aimLeft;
    public Button aimRight;
    public Button aimShoot;

    // Get player components for adding force
    void Start()
    {
        headRB = head.GetComponent<Rigidbody>();
        h = head.GetComponent<Head>();
        transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        aimLeft.gameObject.SetActive(false);
        aimRight.gameObject.SetActive(false);
        aimShoot.gameObject.SetActive(false);
    }

    //rotate cannon on click when left arrow button is pressed (based on first person perspective)
    public void AimLeft()
    {
        transform.Rotate(0f, -15f, 0f, Space.World);
    }

    //rotate cannon on click when right arrow button is pressed (based on first person perspective)
    public void AimRight()
    {
        transform.Rotate(0f, 15f, 0f, Space.World);
    }

    //add force in cannons current forward facing vector and remove UI. change shot to true so head can update
    public void FireCannon()
    {
        headRB.AddForce(transform.forward * firepower);
        h.shot = true;
        aimLeft.gameObject.SetActive(false);
        aimRight.gameObject.SetActive(false);
        aimShoot.gameObject.SetActive(false);

    }
}
