using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointFollower : MonoBehaviour
{
    
    [SerializeField] private GameObject[] waypoints;//tömb a waypointok számára
    private int waypointIndex=0;

    [SerializeField]private float platformSpeed = 2f;//platform mozgási sebessége

  
    private void Update() //ha a jelenlegi waypoint és a platform pozíciója távolságának különbsége kevesebb mint 0,1 akkor a platform a következõ waypointhoz indul
        // Time.delatTime -> FPS függõ sebességszabályzó
    {

        MoveThePlatform();
    }

    private void MoveThePlatform()
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
        }
        catch (Exception e)
        {
            transform.position = Vector2.MoveTowards(transform.position, transform.position, Time.deltaTime * platformSpeed);
            System.IO.File.WriteAllText(Application.persistentDataPath + "error.txt", System.DateTime.Now.ToString() + "-" + e.ToString());

        }
    }
}
