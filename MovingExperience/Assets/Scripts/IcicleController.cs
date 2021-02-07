using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcicleController : MonoBehaviour
{
    public GameObject i;
    public GameObject player;
    Body b;
    bool crossed;

    // Start is called before the first frame update
    void Start()
    {
        b = player.GetComponent<Body>();
        crossed = false;
        StartCoroutine(MakeIcicles(i, 0.2f));
    }

    private void Update()
    {
        if (b.currentPlatform == "Platform 4.5")
        {
            crossed = true;
        }
    }

    IEnumerator MakeIcicles(GameObject icicle, float delay)
    {
        while (!crossed)
        {
            yield return new WaitForSeconds(delay);
            float xPos = Random.Range(27f, 33f);
            float zPos = Random.Range(-10f, 25f);
            icicle.transform.localScale = new Vector3(0.2f, 0.08f, 0.8f);
            GameObject clone = Instantiate(icicle, new Vector3(xPos, 15, zPos), Quaternion.Euler(90, 0, 0)) as GameObject;
        }
    }
}
