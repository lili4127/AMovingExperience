using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{

    public GameObject player;

    private string currentPlatform;
    private GameObject platform;
    Light l;

    // Start is called before the first frame update
    void Start()
    {
        currentPlatform = player.GetComponent<Head>().currentPlatform;
        platform = GameObject.Find(currentPlatform);
        transform.position = platform.transform.position + (Vector3.up * 20);
        transform.LookAt(platform.transform);
        l = this.GetComponent<Light>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        currentPlatform = player.GetComponent<Head>().currentPlatform;

        if(currentPlatform == "Platform 4.5")
        {
            l.range = 500;
        }

        else
        {
            platform = GameObject.Find(currentPlatform);
            transform.position = platform.transform.position + (Vector3.up * 20);
            transform.LookAt(platform.transform);
        }
        
    }
}
