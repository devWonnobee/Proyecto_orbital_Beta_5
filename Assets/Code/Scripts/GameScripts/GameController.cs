using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject showCoin;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject PUActive;

    [SerializeField] PlayerScorer playerScore;
    CoinController coinController;


    public int totalCoins;
    private int totalPlayerCoins;
    private float score;
    public int orbitNumber;
    private int playerScoreToPrint;

    // Estado del juego
    public bool isGameActive;
    public bool isGamePause;
    public bool isGameContinued;

    private void Awake()
    {
        coinController = FindObjectOfType<CoinController>();
        playerScore = FindObjectOfType<PlayerScorer>();
        totalCoins = 0;
        score = 0f;
        instance = this;
        isGameActive = true;
        isGamePause = false;
        isGameContinued = false;
        
    }
    private void Start()
    {
        isPowerUp();
    }
    private void Update()
    {
        score += Time.deltaTime;

    }
    /// <summary>
    /// M�todo que devuelve al jugador a la pantalla de Men�.
    /// </summary>
    public void GoToMenu()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// M�todo que abre o cierra el panel de Pausa y adecua el tiempo a pausado o activo.
    /// </summary>
    /// <param name="state">Activar o desactivar pausa.</param>
    public void PauseGame()
    {
        isGamePause = !isGamePause;
        pausePanel.SetActive(isGamePause);
        pauseButton.SetActive(!isGamePause);
        if (isGamePause) { Time.timeScale = 0;}
        else {Time.timeScale = 1;}
    }

    /// <summary>
    /// M�todo que se encarga de activar el panel de Game Over.
    /// </summary>
    public void GameOver()
    {
        if (orbitNumber <= 0)
        {
            Time.timeScale = 0;
            GameManager.instance.Player.powerUp = false;
            gameOverPanel.SetActive(true);
            gameOverPanel.GetComponent<GameOverMenu>().ContinuePosibility();
            isGameActive = false;
            playerScore.FinalPoint();
            SaveTotalCoins();
            Debug.Log("Game Over");
        }       
    }

    void SaveTotalCoins() 
    {
        totalPlayerCoins = coinController.TotalCoins();
        Debug.Log("Se salvarán: " + totalPlayerCoins);
        GameManager.instance.Player.premium += totalPlayerCoins;
        GameManager.instance.Save();
    }
    /// <summary>
    /// M�todo que se encarga de ajustar los orbitales en funci�n del valor dado.
    /// </summary>
    /// <param name="add">Si se pasa el valor true se a�aden orbitales. False, se restan y se comprueba que no se haya acabado
    /// total de orbitales disponibles.</param>
    public void AddOrbit(bool add)
    {
        if (add) { orbitNumber++; }
        else { orbitNumber--; GameOver(); }
    }
    /// <summary>
    /// M�todo que se encarga de a�adir un n�mero de monedas determinado a la variable en cuesti�n.
    /// </summary>
    /// <param name="value">El valor dado por el que llama al m�todo que actualiza la variable de las
    /// monedas y el texto de las mismas.</param>
    public void AddCoins(int value)
    {
        totalCoins += value;
        coinText.text = totalCoins.ToString();
        StartCoroutine(ShowTotalCoins());
    }
    /// <summary>
    /// Corrutina que activa 1 segundo el texto de las monedas y luego lo vuelve a ocultar.
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowTotalCoins()
    {
        showCoin.SetActive(true);
        yield return new WaitForSeconds(1f);
        showCoin.SetActive(false);
    }

    public void isPowerUp()
    {
        if (!GameManager.instance.Player.powerUp) { PUActive.SetActive(false); }
        else { PUActive.SetActive(true); }
    }

}
