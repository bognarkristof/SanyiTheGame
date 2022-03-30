using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_platform : MonoBehaviour
{

    [SerializeField] private float breakspeed;
    [SerializeField] private float respawnspeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Invoke("DropPlatform", breakspeed);
            
        }
    }


    private void DropPlatform()
    {
        gameObject.active = false;
        Invoke("SpawnPlatform", respawnspeed);
        
    }

    private void SpawnPlatform()
    {
        
        gameObject.active = true;
    }


}
