using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //player and platform variables for cameras to reference
    public GameObject player;
    private string currentPlatform;
    private GameObject platform;

    //camera variables
    public GameObject cam1;
    private AudioListener cam1Audio;

    public GameObject cam2;
    private Vector3 offset2;
    private AudioListener cam2Audio;

    public GameObject cam3;
    private AudioListener cam3Audio;

    private int activeCam;

    // set up all cameras with camera 2 being the first active camera
    void Start()
    {
        SetCamera1();
        SetCamera2();
        SetCamera3();
        activeCam = 2;
    }

    // update camera positions based on how player has moved this frame
    void LateUpdate()
    {
        //Cam 1: change First Person Cam based on direction one is advancing (for cannon turn camera around)
        if (!player.GetComponent<Head>().shot)
        {
            cam1.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        //FP Cam looks forward in the z axis direction
        else
        {
            cam1.transform.rotation = Quaternion.identity;
            cam1.transform.position = player.transform.position + Vector3.up;
        }

        //reset cam2 and cam3 offsets based on new player position
        cam2.transform.position = player.transform.position + offset2;

        currentPlatform = player.GetComponent<Head>().currentPlatform;
        platform = GameObject.Find(currentPlatform);
        cam3.transform.position = new Vector3(platform.transform.position.x, 60, platform.transform.position.z);
    }

    //change cameras based on currently active camera
    public void ChangeCamera()
    {

        if (activeCam >= 3)
        {
            cam1.SetActive(true);
            cam1Audio.enabled = true;
            cam2.SetActive(false);
            cam2Audio.enabled = false;
            cam3.SetActive(false);
            cam3Audio.enabled = false;

            activeCam = 1;
        }

        else if (activeCam <= 1)
        {
            cam1.SetActive(false);
            cam1Audio.enabled = false;
            cam2.SetActive(true);
            cam2Audio.enabled = true;
            cam3.SetActive(false);
            cam3Audio.enabled = false;

            activeCam = 2;
        }

        else if (activeCam == 2)
        {
            cam1.SetActive(false);
            cam1Audio.enabled = false;
            cam2.SetActive(false);
            cam2Audio.enabled = false;
            cam3.SetActive(true);
            cam3Audio.enabled = true;

            activeCam = 3;
        }
    }

    //FP Cam sits one unit vector up from player head position facing forward direction
    private void SetCamera1()
    {
        cam1.SetActive(false);
        cam1Audio = cam1.GetComponent<AudioListener>();
        cam1Audio.enabled = false;
        cam1.transform.rotation = Quaternion.identity;
        cam1.transform.position = player.transform.position + Vector3.up;
    }

    //cam2 has a 20 offset from the players current position and follows the player
    private void SetCamera2()
    {
        cam2.SetActive(true);
        cam2Audio = cam2.GetComponent<AudioListener>();
        cam2Audio.enabled = true;
        cam2.transform.rotation = Quaternion.Euler(45, 0, 0);
        offset2 = (10 * Vector3.up) + (-20 * Vector3.forward);
        cam2.transform.position = player.transform.position + offset2;
    }

    //cam 3 has a 60 offset above the current platform looking directly down at the center of it
    private void SetCamera3()
    {
        cam3.SetActive(false);
        cam3Audio = cam3.GetComponent<AudioListener>();
        cam3Audio.enabled = false;
        currentPlatform = player.GetComponent<Head>().currentPlatform;
        platform = GameObject.Find(currentPlatform);
        cam3.transform.position = new Vector3(platform.transform.position.x, 60, platform.transform.position.z);
        cam3.transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
