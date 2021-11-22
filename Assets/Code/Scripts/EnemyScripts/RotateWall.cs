using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWall : MonoBehaviour
{
    //Creamos una variable para la velocidad mínima, la máxima, y la generada aleatoriamente.
    [SerializeField] private float minmodSpeed;
    [SerializeField] private float maxmodSpeed;
    public float modspeed;
    public float rotationSpeed;
    public GameObject target;


    private void Start()
    {
        modspeed = Random.Range(minmodSpeed, maxmodSpeed);
        rotationSpeed += modspeed;
    }
    private void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
