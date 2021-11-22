using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    private bool continue_remaining;
    public bool continued = false;

    [SerializeField] private Button continueButton;
    [SerializeField] private Sprite[] spriteButton;
    [SerializeField] private GameObject pauseButton;

    GameController gameController;
    CoinController coinController;

    private void Awake()
    {
        continue_remaining = true;
        gameController = FindObjectOfType<GameController>();
        coinController = FindObjectOfType<CoinController>();
    }
    /// <summary>
    /// M�todo que se encarga de reiniciar el nivel desde el principio.
    /// </summary>
    public void ReloadLevel()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    /// <summary>
    /// M�todo que se lanza cuando se llega a la pantalla de Game Over y 
    /// valora el valor de la variable que indica si se puede continuar o no.
    /// </summary>
    public void ContinuePosibility()
    {
        //Debug.Log(continue_remaining);
        if (continue_remaining)
        { 
            continueButton.GetComponent<Image>().sprite = spriteButton[0];
        }
        else 
        {
            continueButton.GetComponent<Image>().sprite = spriteButton[1];
            continueButton.interactable = false;
        }
        pauseButton.SetActive(false);
    }

    public void Continue()
    {
        gameController.isPowerUp();
        GameObject.Find("Player").GetComponent<CentralSphereMovement>().PowerUp("SimpleBall");
        GameObject.Find("Player").GetComponent<CentralSphereMovement>().PowerUp("GhostPU");
        this.gameObject.SetActive(false);
        continue_remaining = false;
        pauseButton.SetActive(true);
        gameController.isGameActive = true;
        gameController.isGameContinued = true;
        Time.timeScale = 1;
        continued = true;
        coinController.Continue();
        
    }
    /// <summary>
    /// M�todo que abre el panel de la tienda.
    /// </summary>
    public void ShopPanel()
    {

    }
}
