using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : MonoBehaviour
{
    public static int playerCoins = 0;
    public int[] valueCoins = {1,5,15};
    private CoinController coinController;
    // probando rotacion de la moneda
    //private float speedRotation = 1f;

    GameController gc_addCoins;

    void Start()
    {
        gc_addCoins = GameObject.FindObjectOfType<GameController>();
        coinController = GameObject.Find("CoinManager").GetComponent<CoinController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Orbital"))
        {
            PickedPlayerCoin();

            Destroy(gameObject);
            
        }

    }
    public void PickedPlayerCoin()
    {
        int coinNum = Random.Range(0, 2);
        playerCoins = valueCoins[coinNum];
        coinController.PlayerCoins(playerCoins);
        // Los mensajes esta dentro del script PlayerScorer.cs
        gc_addCoins.AddCoins(playerCoins);
    }
}
