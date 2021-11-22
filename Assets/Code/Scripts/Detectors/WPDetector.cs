using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WPDetector : MonoBehaviour
{
    // Waypoint Configuration
    public GameObject[] waypoints;
    public int currentWP = 0;
    public float dist_WP_detect = 1f;
    public float rotation_Speed = 0.5f;
    
    public float speed;
    private float t = 1;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (waypoints[currentWP].transform.position.z > this.transform.position.z) 
        {
            waypoints = GameObject.FindGameObjectsWithTag("waypoint");
            waypoints = waypoints.OrderBy(x => x.gameObject.name).ToArray();
        }

            WaypointFollower();
    }
    void WaypointFollower() 
    {
        if(waypoints.Length == 0) return;

            Vector3 lookAtGoal = new Vector3(waypoints[currentWP].transform.position.x, 
                                            this.transform.position.y, 
                                            waypoints[currentWP].transform.position.z);

            Vector3 direction = lookAtGoal - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                        Quaternion.LookRotation(direction), 
                                        Time.deltaTime*rotation_Speed);
            

            if(direction.magnitude < dist_WP_detect)
            {
                
                currentWP++;
                if(currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }
            transform.position = Vector3.MoveTowards(this.transform.position, Vector3.Lerp(this.transform.position,waypoints[currentWP].transform.position,t), Time.deltaTime * speed);
    }
}
