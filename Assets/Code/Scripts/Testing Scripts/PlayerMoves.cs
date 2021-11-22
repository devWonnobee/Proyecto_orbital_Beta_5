using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{


    // Score del jugador get from distance
    int playerScore;
    int score;
    float get_score;
    
    private PlayerScorer playerScorer;
    // ultima posicion de la esfera
    private Vector3 player_lastPosition;
    private Vector3 player_currentPosition;

    float prevPlayerZ;
    

    
    
    void Start()
    {
        playerScorer = FindObjectOfType<PlayerScorer>();
        player_currentPosition = this.transform.position;
        prevPlayerZ = this.transform.position.z;
        score = 0;
    }

    void Update()
    {
        PlayerScoreDistance();
    }

    void FixedUpdate()
    {
        
        
        player_lastPosition = transform.position;
       
        //distance = Vector3.Distance(player_currentPosition, transform.position);

        
        //transform.position = Vector3.MoveTowards(player_lastPosition, Vector3.Lerp(player_lastPosition, target,t), speed);
    }

    void PlayerScoreDistance() 
    {
        if(prevPlayerZ < this.transform.position.z) 
        {
            get_score += this.transform.position.z - prevPlayerZ;
            prevPlayerZ = this.transform.position.z;
            score = ((int) get_score);
        }
        playerScorer.PlayerScoreIncrementer(score, 0);


    }


    //private void SpawntargetPosition ()
    //{
    //    bool targetPositioned = false;
    //    while (!targetPositioned)
    //    {
    //        Vector3 targetPosition = new Vector3(Random.Range(-7f, 7f), 0, Random.Range(0f, 100f));
    //        if((targetPosition - transform.position).magnitude < 10)
    //        {
    //            continue;
    //        } 
    //        else
    //        {
    //            Instantiate(points, targetPosition, Quaternion.identity);
    //            targetPositioned = true;
    //            target = targetPosition;
    //            transform.position = Vector3.MoveTowards(player_lastPosition, Vector3.Lerp(player_lastPosition, target, t), speed);
    //        }
    //    }
    //    Debug.Log(targetPositioned);
    //}


    
    //private void PlayerMoveToForward()
    //{
        
    //    transform.Translate(new Vector3(0,0,2f) * Time.deltaTime);
    //    //Debug.Log(distance);
    //}

    //private void PlayerMoveToLeft()
    //{
    //    int rDistance = (int) Mathf.Round(distance);
    //    //Debug.Log(rDistance);
    //    if (rDistance == 10)
    //    {
            
    //            transform.Translate(new Vector3(-1000f, 0, 5f) * Time.deltaTime);
    //            //int timer = (int) Mathf.Round(Time.time);
    //            //int coolDown = reachThisDistance -= timer;
    //            //Debug.Log(coolDown);
    //            //if (coolDown == 0)
    //            //{
    //            //    reached = false;
    //            //}
            
    //    }
    //}

    //private void PlayerMoveToRight()
    //{
    //    int rDistance = (int)Mathf.Round(distance);
    //    if (rDistance == 10)
    //    {
    //        transform.Translate(new Vector3(20f,0,0) * Time.deltaTime);
    //    }
    //}
}
