using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_bouncing : MonoBehaviour
{
    bool dir;

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.y > 10)
        {
            dir = true;
        }


        if(transform.localScale.y < 5)
        {
            dir = false;
        }


        if ( dir == true)
        {
            gameObject.transform.localScale -= new Vector3(0, 0.005f, 0);
        }
        else
        {
            gameObject.transform.localScale += new Vector3(0, 0.005f, 0);
        }

    }
}
