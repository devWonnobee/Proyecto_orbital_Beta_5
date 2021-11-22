using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disolve : MonoBehaviour
{


    public Material[] material;
    Vector3 Position;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        Position = player.transform.position;
        for (int i = 0; i < material.Length; i ++)
        {
            material[i].SetVector("Vector3_ce8688b1b04348e5877e0addbb983a8b", Position);
        }
       

    }
}
