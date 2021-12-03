using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{
    GameController gameController;

    [SerializeField] public TMP_Text msgScore_Text;
    [SerializeField] public GameObject msgScore_Object;

    [Header ("Total Player Score Stat")]
    public int current_score;
    public int update_score;
    public int save_score;

    [Header ("Coin Stat")]
    public int coin_divider = 100;
    public int convertedCoins;
    private int first_farm_coins;
    private int second_farm_coins;
    public static int firstTotalCoins;
    public static int secondTotalCoins;
    public static int playerTotalCoins;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        
    }

    /// <summary>
    /// Esta funcion recoge las monedas en la partida y lo clasifica del primer partida y continuación
    /// </summary>
    /// <param name="getcoins">Recoge las monedas</param>
    public void PlayerCoins(int getcoins) {
        first_farm_coins += getcoins;
        if(gameController.isGameContinued)
        {
            second_farm_coins += getcoins;
        }
    }
    /// <summary>
    /// Esta funcion convierte los puntos en monedas dividido el valor de los puntos entre un valor modificable en la variable coin_divider
    /// </summary>
    /// <param name="points">Recoge los puntos</param>
    /// <returns></returns>
    public int PointsConverterToCoin(int points)
    {
        int coins = 0;
        if (points >= coin_divider)
        {
            coins = points / coin_divider;
        }
        return coins;
    }
    /// <summary>
    /// Este funcion recoge el valor de puntos en el script script PlayerController y hace la funcion de sumar los datos
    /// </summary>
    /// <param name="gScore"></param>
    public void GetScoreFromPlayerController(int gScore)
    {
        current_score = gScore;
        
        if(!gameController.isGameActive)
        {
            if(!gameController.isGameContinued) 
            {
                Debug.Log("Coin converter 1");
                convertedCoins = PointsConverterToCoin(current_score);
                firstTotalCoins = first_farm_coins + convertedCoins;
                
            }
            else
            {
                Debug.Log("Coin converter 2");
                current_score = gScore - current_score;
                //secondTotalScore = playerTotalScore - firstTotalScore;
                int convertedCoins = PointsConverterToCoin(current_score);
                secondTotalCoins = second_farm_coins + convertedCoins;
            }            
        } 
    }
    /// <summary>
    /// Todavia no se lo que es
    /// </summary>
    public void Continue()
    {
        msgScore_Object.SetActive(false);
    }

    /// <summary>
    /// Mostrar los coins al final de la partida
    /// </summary>
    public void PrintTotalCoins()
    {
        if(!gameController.isGameContinued)
        {
            msgScore_Object.SetActive(true);
            msgScore_Text.text = "Coins: \n" + first_farm_coins + "\n Converted: \n " + convertedCoins;
        }
        else
        {
            int playerTotalCoinsToPrint = firstTotalCoins + secondTotalCoins;

            msgScore_Object.SetActive(true);
            msgScore_Text.text = "Coins: \n " + playerTotalCoinsToPrint;


        }

    }
    /// <summary>
    /// Recoge el total de monedas de la partida
    /// </summary>
    /// <returns>Player Total Coins to save data</returns>
    public int TotalCoins()
    {
        playerTotalCoins = secondTotalCoins + firstTotalCoins;
        return playerTotalCoins;

    }
}
