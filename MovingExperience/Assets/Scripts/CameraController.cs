using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private string currentPlatform;
    private GameObject platform;

    public GameObject cam1;
    private AudioListener cam1Audio;

    public GameObject cam2;
    private Vector3 offset2;
    private AudioListener cam2Audio;

    public GameObject cam3;
    private AudioListener cam3Audio;

    private int activeCam;

    // Start is called before the first frame update
    void Start()
    {
        SetCamera1();
        SetCamera2();
        SetCamera3();
        activeCam = 2;
    }

    void LateUpdate()
    {
        //Cam 1: change FP Cam based on direction one is advancing
        if (!player.GetComponent<Head>().shot)
        {
            cam1.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else
        {
            cam1.transform.rotation = Quaternion.identity;
            cam1.transform.position = player.transform.position + Vector3.up;
        }
        
        cam2.transform.position = player.transform.position + offset2;

        currentPlatform = player.GetComponent<Head>().currentPlatform;
        platform = GameObject.Find(currentPlatform);
        cam3.transform.position = new Vector3(platform.transform.position.x, 60, platform.transform.position.z);
    }

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

    private void SetCamera1()
    {
        cam1.SetActive(false);
        cam1Audio = cam1.GetComponent<AudioListener>();
        cam1Audio.enabled = false;
        cam1.transform.rotation = Quaternion.identity;
        cam1.transform.position = player.transform.position + Vector3.up;
    }

    private void SetCamera2()
    {
        cam2.SetActive(true);
        cam2Audio = cam2.GetComponent<AudioListener>();
        cam2Audio.enabled = true;
        cam2.transform.rotation = Quaternion.Euler(45, 0, 0);
        offset2 = (10 * Vector3.up) + (-20 * Vector3.forward);
        cam2.transform.position = player.transform.position + offset2;
    }

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
