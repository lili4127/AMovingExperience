using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icicle : MonoBehaviour
{
    public GameObject body;
    Renderer bodyRenderer;
    Color ogColor;
    public HealthBar healthBar;

    private void Awake()
    {
        transform.localScale = new Vector3(0.2f, 0.08f, 0.8f);
    }

    // Start is called before the first frame update
    void Start()
    {
        bodyRenderer = body.GetComponent<Renderer>();
        ogColor = bodyRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Head" || other.gameObject.tag == "Body")
        {
            healthBar.LoseHealth(8);
        }

        Destroy(GameObject.Find("Icicle(Clone)"), 0.1f);
    }

}
