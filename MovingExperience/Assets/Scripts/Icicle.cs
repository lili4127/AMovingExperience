using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    public GameObject body;
    public HealthBar healthBar;

    //set size of icicles
    private void Awake()
    {
        transform.localScale = new Vector3(0.2f, 0.08f, 0.8f);
    }

    //if icicle hit a player flash screen red and remove health
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Head" || other.gameObject.tag == "Body")
        {
            healthBar.LoseHealth(5);
        }

        //destroy instatiated icicles from coroutine
        Destroy(GameObject.Find("Icicle(Clone)"), 0.1f);
    }

}
