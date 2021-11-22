using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [Header("Texto para el Score")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text showPointsWsText;
    [SerializeField] private TMP_Text showPointsNtText;

    [SerializeField] private GameObject showPointsWs;
    [SerializeField] private GameObject showPointsNt;

    public int playerTotalScore;
    private int current_score;
    private int playerWallScore;
    
    PlayerMoves playerDistance;


    private float _Timer;
    //private float prev_Timer;
    //private float pressed_time;
    [SerializeField]
    public float set_timeNotouch = 5f;
    //[SerializeField] private int add_Score = 5;
    [SerializeField] private int add_CloseWall_Score = 5;

    // Instanciar GameController
    public GameController gameController;
    public int score_to_coins;
    //private int divide_number = 5;

    // Instanciar direccion de giro
    [SerializeField]
    private Transform orbit;
    private float orbit_current_rotation;
    private float angleSoFar, angleLastPos;

    void Start()
    {
        playerTotalScore = 0;
        //gameController = GameObject.Find("GameController").GetComponent<GameController>();
        orbit = GetComponent<Transform>();

        //prev_Timer = 0;
        //pressed_time = 0;

        angleSoFar = 0;
        angleLastPos = orbit.localEulerAngles[1];

    }

    void Update()
    {
        _Timer = Time.fixedTime;
        //RotationPlayerScore();
        //PlayerDistanceScore();
        //PlayerNoTouchScreen();
        //GetScoreToSum();
        //PlayerScoreCoinConverter();
        //Debug.Log("current score " + current_score);
        playerTotalScore = current_score;
        scoreText.text = playerTotalScore.ToString();
    }

    private void RotationPlayerScore()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float orbit_current_rotation = orbit.transform.localEulerAngles[1];
            angleSoFar += angleLastPos - orbit_current_rotation;
            if (angleSoFar > 359)
            {
                Debug.LogWarning("Wow 360 " + angleSoFar);
                
            }
            else if (angleSoFar < 359)
            {
                Debug.LogWarning("Uh oh not 360 " + angleSoFar);
                
            }

            Debug.LogWarning(orbit_current_rotation);
        }

    }

    public IEnumerator ShowTextOnTimeWallScore()
    {
        showPointsWs.SetActive(true);
        yield return new WaitForSeconds(2f);
        showPointsWs.SetActive(false);
    }

    public IEnumerator ShowTextOnTimeNoTouch()
    {
        showPointsNt.SetActive(true);
        yield return new WaitForSeconds(2f);
        showPointsNt.SetActive(false); 
    }
    void PlayerDistanceScore()
    {
        //current_score = playerDistance.playerScore;
    }

    public void PlayerWallScore()
    {
        playerWallScore = add_CloseWall_Score;
        showPointsWsText.text = "Has pasado cerca de un muro: " + playerWallScore + " puntos.";
        StartCoroutine(ShowTextOnTimeWallScore());
    }
     void GetScoreToSum()
    {
        if(playerWallScore > 0)
        {
            current_score += playerWallScore;
        }
            
        
    }
    // void PlayerNoTouchScreen()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
            
    //         pressed_time = _Timer;
            
    //         if (prev_Timer != pressed_time && playerDistance.playerScore > 0)
    //         {
    //             float dif_time = pressed_time - prev_Timer;
    //             if (dif_time >= set_timeNotouch)
    //             {
    //                 current_score += add_Score;
    //                 showPointsWsText.text = "Has conseguido: " + add_Score + " puntos. Sin tocar la pantalla.";
    //                 StartCoroutine(ShowTextOnTimeNoTouch());
    //             }
    //         }
    //         prev_Timer = _Timer;         
    //     }
    // }

    public void PlayerScoreCoinConverter()
    {
        //if (!gameController.isGameActive)
        //{   
        //    score_to_coins = playerTotalScore / divide_number;
        //} 
        
    }
}
