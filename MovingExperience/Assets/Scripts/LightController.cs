using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    //player and platform variables for light to point at
    public GameObject player;

    private string currentPlatform;
    private GameObject platform;
    Light l;

    //find player position and set light up relative to current platform to spotlight it
    void Start()
    {
        currentPlatform = player.GetComponent<Head>().currentPlatform;
        platform = GameObject.Find(currentPlatform);
        transform.position = platform.transform.position + (Vector3.up * 20);
        transform.LookAt(platform.transform);
        l = this.GetComponent<Light>();
    }

    //update player position if moved in frame so light can adjust to new platform if necessary
    void LateUpdate()
    {
        currentPlatform = player.GetComponent<Head>().currentPlatform;

        //increase light range on 4.5 so player can see more of the rotating bridge
        if(currentPlatform == "Platform 4.5")
        {
            l.range = 500;
        }

        //update light to current platform
        else
        {
            platform = GameObject.Find(currentPlatform);
            transform.position = platform.transform.position + (Vector3.up * 20);
            transform.LookAt(platform.transform);
        }
        
    }
}
