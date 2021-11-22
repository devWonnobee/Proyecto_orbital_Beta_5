using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralSphereMovement : MonoBehaviour
{
    //Variables de velocidad y posici�n para la instanciaci�n de nuevos orbitales.
    //public float speed;
    private Vector3 spawnPosition;

    //Variables de posiciones y prefabs de objetos.
    [SerializeField] private GameObject centralSphere;
    [SerializeField] private GameObject orbital;
    [SerializeField] private GameObject[] actualOrbitInScene;
    [SerializeField] private GameObject halo;

    //Variable de GameController
    private GameController gameController;

    private void Start()
    {
        StartCoroutine(MultipleBall(1));
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void Update()
    {
        if (!gameController.isGameActive)
        {
            StopAllCoroutines();
        }
    }
    /// <summary>
    /// M�todo que se encarga de iniciar las corrutinas de Power Up.
    /// </summary>
    public void PowerUp(string power)
    {
        actualOrbitInScene = GameObject.FindGameObjectsWithTag("Orbital");
        switch (power)
        {
            case "SimpleBall":
                StartCoroutine(MultipleBall(1));
                break;
            case "MultiplePU":
                StartCoroutine(MultipleBall(2));
                break;
            case "SpeedPU":
                orbital.GetComponent<OrbitalMovement>().SpeedUp(true);
                break;
            case "FrostPU":
                orbital.GetComponent<OrbitalMovement>().SpeedUp(false);
                break;
            case "GhostPU":
                StartCoroutine(GhoshForm());
                break;
            case "DestructionPU":
                StartCoroutine(DestructionForm());
                break;
            case "NearPU":
                StartCoroutine(NearForm());
                break;
        }
        
    }

    /// <summary>
    /// Corrutina que genera dos orbitales nuevos en un espacio de tiempo variable de 1 a 3 segundos.
    /// </summary>
    /// <returns></returns>
    IEnumerator MultipleBall(int number)
    {
        spawnPosition = new Vector3(centralSphere.transform.position.x, centralSphere.transform.position.y, centralSphere.transform.position.z - 3f);
        for (int i = 0; i< number; i++)
        {
            Instantiate(orbital, spawnPosition, orbital.transform.rotation);
            GameController.instance.AddOrbit(true); // En esta linea error NULL
            yield return new WaitForSeconds(Random.Range(1f,3f));
        }
        
    }
    /// <summary>
    /// Corrutina que desactiva el collider del orbital para que pueda pasar por los muros sin ser da�ado.
    /// </summary>
    /// <returns></returns>
    IEnumerator GhoshForm()
    {
        for (int i = 0; i < actualOrbitInScene.Length; i++)
        {
            actualOrbitInScene[i].GetComponent<OrbitalMovement>().RemoveCollider(false);
        }
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < actualOrbitInScene.Length; i++)
        {
            actualOrbitInScene[i].GetComponent<OrbitalMovement>().RemoveCollider(true);
        }
    }
    /// <summary>
    /// Corrutina que activa una variable que permite destruir muros durante un tiempo.
    /// </summary>
    /// <returns></returns>
    IEnumerator DestructionForm()
    {
        orbital.GetComponent<HealthPlayer>().Invencible(true);
        yield return new WaitForSeconds(5f);
        orbital.GetComponent<HealthPlayer>().Invencible(false);
    }
    /// <summary>
    /// Corrutina que permite que el orbital se ponga m�s cerca de la esfera central durante un periodo de tiempo.
    /// </summary>
    /// <returns></returns>
    IEnumerator NearForm()
    {
        for(int i= 0; i<actualOrbitInScene.Length; i++)
        {
            actualOrbitInScene[i].transform.position = Vector3.MoveTowards(actualOrbitInScene[i].transform.position, centralSphere.transform.position, 2f);
        }
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < actualOrbitInScene.Length; i++)
        {
            actualOrbitInScene[i].transform.position = Vector3.MoveTowards(actualOrbitInScene[i].transform.position, centralSphere.transform.position, -2f);
        }
    }
    public IEnumerator DisableHalo()
    {
        yield return new WaitForSeconds(5f);
        halo.SetActive(false);
    }
}
