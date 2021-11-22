using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpButton : MonoBehaviour
{
    [SerializeField] private ShopObject[] activePowerUp;
    [SerializeField] private Button buttonPU;
    [SerializeField] private Image buttonImage;
    [SerializeField] private float timer;
    [SerializeField] private float timerCD;
    [SerializeField] private GameObject panelCD;
    [SerializeField] private TMP_Text textCD;


    private void Start()
    {
        activePowerUp = Resources.LoadAll<ShopObject>("Consumibles");
        buttonPU.enabled = false;
        foreach(ShopObject obj in activePowerUp)
        {
            if(obj.productName == GameManager.instance.Player.activePowerUp)
            {
                buttonPU.enabled = true;
                timerCD = obj.productCD;
                RefillButtonPU(obj);
            }
        }
    }
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            panelCD.SetActive(true);
            textCD.text = timer.ToString("F0");
            buttonPU.interactable = false;
        }
        else
        {
            panelCD.SetActive(false);
            buttonPU.interactable = true;
        }
    }
    /// <summary>
    /// M�todo que se llama al inicio de la partida para rellenar con los valores del Power Up activo.
    /// </summary>
    /// <param name="power">Se pasa el power up que est� activo en el player en caso de que lo hubiera.</param>
    private void RefillButtonPU(ShopObject power)
    {
        Debug.Log(power.productName);
        buttonImage.sprite = power.productImagen;
        buttonPU.onClick.AddListener(() => UsePower(power.productName));
    }

    private void UsePower(string power)
    {
        GameObject.Find("Player").GetComponent<CentralSphereMovement>().PowerUp(power);
        timer = timerCD;
    }
}