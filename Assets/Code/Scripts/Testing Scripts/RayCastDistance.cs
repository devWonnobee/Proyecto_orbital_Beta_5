using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDistance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 50f))
        {
            if(hit.transform.tag == "Enemy")
            {
                Debug.DrawRay(transform.position, Vector3.forward, Color.red);
            } 
            else
            {
                Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
                Debug.DrawRay(transform.position, forward, Color.green);
                Vector3 left = transform.TransformDirection(Vector3.left) * 10;
                Debug.DrawRay(transform.position, left, Color.blue);
                Vector3 right = transform.TransformDirection(Vector3.right) * 10;
                Debug.DrawRay(transform.position, right, Color.white);
            }
        }

    }
}
