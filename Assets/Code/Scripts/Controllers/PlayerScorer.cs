using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScorer : MonoBehaviour
{
    GameController gameController;
    CoinController coinController;

    [SerializeField] public TMP_Text playerScore_Text;
    [SerializeField] public GameObject playerScore_Obj;


    [SerializeField] public TMP_Text msgScore_Text;
    [SerializeField] public GameObject msgScore_Object;

    [SerializeField] public TMP_Text combo_Text;
    [SerializeField] public GameObject combo_Object;
    
    [Header ("Touch Screen Config")]
    [SerializeField] public float setTouchScreenTimer;
    public int addScore_TS;
    public bool timerIntRunning = false;
    public float _statTimer;

    GameObject playerDistance;
    Transform orbitRotation;

    [Header ("Total Player Score Stat")]
    public static int playerTotalScore; // Variable para
    public int current_score;
    public int update_score;
    public int save_score;
    [Header ("Incrementer Points Stats")]
    public int _touchScreenPoints;
    public int _fullRotationPoints;
    public int _nearWallPoints;
    public int _distancePoints;
    private int firstTotalScore;
    private int secondTotalScore;
    

    [Header ("Near Wall Scorer")]
    public static int level;
    private float timer;
    private float timerCountdown;
    private bool timeDown;

    void Start()
    {
        playerDistance = GameObject.FindGameObjectWithTag("Player");
        gameController = FindObjectOfType<GameController>();
        coinController = FindObjectOfType<CoinController>();
        playerTotalScore = 0;
        save_score = 0;
        current_score = 0;

        level = 0;
        timeDown = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { PlayerTouchScreenIncrementer(); }
        _statTimer += Time.deltaTime;
        if (_statTimer > setTouchScreenTimer) { TimerTouchScreenScore(); }
        if(timeDown) {timerCountdown -= Time.deltaTime;}
        if(timerCountdown <= 0)
        {
            level = 0;
            timeDown = false;
        }
    }

    public void PlayerTotalScorePrint(int gscore) 
    {
        
        playerTotalScore = gscore;
        playerScore_Text.text = playerTotalScore.ToString();
        
    }

    public void FinalPoint()
    {
        Debug.Log("FinalPoint :" + playerTotalScore);
        coinController.CoinConverter(playerTotalScore);
    }

    public void PlayerScoreIncrementer(int increaseScore, int addedScore)
    {
        if(addedScore > 0) {
            save_score += addedScore;
        }

        update_score = increaseScore;
     
        _distancePoints = increaseScore;
        current_score = update_score;
        
        current_score = save_score + update_score;
        PlayerTotalScorePrint(current_score);
    }

    void PlayerTouchScreenIncrementer()
    {
        _statTimer = 0;               
    }
    void TimerTouchScreenScore()
    {
        PlayerTouchScreenScore(addScore_TS);
        combo_Text.text = addScore_TS.ToString();
        StartCoroutine(PlayerComboDisplay());
        _statTimer = 0;
    }        
    public void PlayerNearWallScore (int getscore) 
    {
        int score_to_add = getscore;
        _nearWallPoints += getscore;
        PlayerScoreIncrementer(0, score_to_add);
    }
    
    public void PlayerFullRotationScore(int getscore)
    {
        _fullRotationPoints += getscore;
        PlayerScoreIncrementer(0,getscore);
    }

    void PlayerTouchScreenScore (int getscore)
    {
        int score_to_add = getscore;
        _touchScreenPoints += score_to_add;
        PlayerScoreIncrementer(0, score_to_add);
    }

    public void OrbitNearWall() 
    {
        level ++;
        OrbitCombo();
    }

    private void OrbitCombo()
    {
        switch (level)
        {
            case 1:
                combo_Text.text = "20";
                StartCoroutine(PlayerComboDisplay());
                PlayerNearWallScore(20);
                timer = 6f;
                break;
            case 2:
                combo_Text.text = "50";
                StartCoroutine(PlayerComboDisplay());
                PlayerNearWallScore(50);
                timer = 5f;
                break;
            case 3:
                combo_Text.text = "110";
                StartCoroutine(PlayerComboDisplay());
                PlayerNearWallScore(110);
                timer = 4f;
                break;
            case 4:
                combo_Text.text = "180";
                StartCoroutine(PlayerComboDisplay());
                PlayerNearWallScore(180);
                timer = 3f;
                break;
            case 5:
                combo_Text.text = "234";
                StartCoroutine(PlayerComboDisplay());
                PlayerNearWallScore(234);
                timer = 2f;
                break;
            case 6:
                combo_Text.text = "500";
                StartCoroutine(PlayerComboDisplay());
                PlayerNearWallScore(327);
                timer = 1f;
                break;
            case 7:
                combo_Text.text = "Fin del Combo";
                StartCoroutine(PlayerComboDisplay());
                break;
        }
        timerCountdown = timer;
        timeDown = true;
    }

    void SavePlayerTotatScore(int getTotalScore)
    {
        if(!gameController.isGameActive)
        {
            playerTotalScore = getTotalScore;
            Debug.Log(playerTotalScore);
        }
        
    }

    

    IEnumerator PlayerScoreDisplay() 
    {
        msgScore_Object.SetActive(true);
        yield return new WaitForSeconds(1f);
        msgScore_Object.SetActive(false);
    }
    IEnumerator PlayerComboDisplay() 
    {
        combo_Object.SetActive(true);
        yield return new WaitForSeconds(1f);
        combo_Object.SetActive(false);
    }

}
