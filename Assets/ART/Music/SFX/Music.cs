using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    public AudioSource audiosouce;
    // Start is called before the first frame update
    void Start()
    {

        audiosouce.pitch = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (audiosouce.pitch < 0.04f)
        {

        }
        else
        {
            audiosouce.pitch = audiosouce.pitch - 0.005f;
        }
        
    }
}
