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
    public int current_Coins;
    public int save_Coins;
    public static int firstTotalCoins;
    public static int secondTotalCoins;
    public static int playerTotalCoins;
    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCoins(int getcoins) {
        current_Coins += getcoins;
        if(gameController.isGameContinued)
        {
            save_Coins += getcoins;
        }
    }

    public void CoinConverter(int gScore)
    {
        
        if(!gameController.isGameActive)
        {
            if(!gameController.isGameContinued) 
            {
                Debug.Log("Coin converter 1");
                convertedCoins = gScore / coin_divider;
                current_score = gScore; 
                firstTotalCoins = current_Coins + convertedCoins;
                playerTotalCoins = firstTotalCoins;
                msgScore_Object.SetActive(true);
                Debug.Log("Monedas\n Conseguidas: " + current_Coins + "\n Convertidas: " + convertedCoins + "\n Total: " + firstTotalCoins);
                msgScore_Text.text = "Monedas\n Conseguidas: " + current_Coins + "\n Convertidas: " + convertedCoins + "\n Total: " + firstTotalCoins;
            }
            else
            {
                Debug.Log("Coin converter 2");
                current_score = gScore - current_score;
                //secondTotalScore = playerTotalScore - firstTotalScore;
                convertedCoins = current_score / coin_divider;
                secondTotalCoins = save_Coins + convertedCoins;
                playerTotalCoins = secondTotalCoins;
                msgScore_Object.SetActive(true);
                msgScore_Text.text = "Monedas \n Total: " + (firstTotalCoins + secondTotalCoins);
            }

            
        } 
    }

    public void Continue()
    {
        msgScore_Object.SetActive(false);
    }

    public int TotalCoins()
    {
        Debug.Log("Primer "+playerTotalCoins);
        return playerTotalCoins;

    }
}
