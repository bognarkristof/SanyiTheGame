using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAtcivate : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)//ha a player objektum hozz��r a platformhoz akkor aktiv�l�dik
    {
        if (collision.gameObject.name == "Player")
        {
            
            gameObject.GetComponent<waypointFollower>().enabled = true;


        }


    }

}
