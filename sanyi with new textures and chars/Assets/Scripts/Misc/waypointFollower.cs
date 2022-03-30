using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointFollower : MonoBehaviour
{
    
    [SerializeField] private GameObject[] waypoints;//t�mb a waypointok sz�m�ra
    private int waypointIndex=0;

    [SerializeField]private float platformSpeed = 2f;//platform mozg�si sebess�ge

  
    private void Update() //ha a jelenlegi waypoint �s a platform poz�ci�ja t�vols�g�nak k�l�nbs�ge kevesebb mint 0,1 akkor a platform a k�vetkez� waypointhoz indul
        // Time.delatTime -> FPS f�gg� sebess�gszab�lyz�
    {
        try
        {
            if (Vector2.Distance(waypoints[waypointIndex].transform.position, transform.position) < .1f)
            {
                waypointIndex++;
                if (waypointIndex >= waypoints.Length)
                {
                    waypointIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * platformSpeed);
        } catch(System.IO.IOException e)
        {
            Debug.Log(e.StackTrace + "sadshakidh");
            
        }
        
    }
}
