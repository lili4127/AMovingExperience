using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//answers.unity.com/questions/620146/how-to-gradually-grow-and-shrink-an-object.html
public class RingController : MonoBehaviour
{
    float scaleRate = 1.0f;
    float minScale = 0.5f;
    float maxScale = 10f;
    public float speed = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scale();
    }
 
 void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate * Time.deltaTime * speed;
    }

    void Scale()
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate();
    }
}
