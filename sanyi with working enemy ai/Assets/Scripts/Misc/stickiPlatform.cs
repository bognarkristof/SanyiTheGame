using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickiPlatform : MonoBehaviour
{

    private void OnCollisionExit2D(Collision2D collision)//elõzõ fuggvény ellentéte, ha leugrik a platformtól akkor eltûnik a parent tulajdonság így nem mozognak együtt
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Player_Hero" || collision.gameObject.name == "Player_Bandit" || collision.gameObject.name == "Player_Cemetry_Hero")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//ha a player objektum hozzáér a platformhoz akkor vele fog mozigni
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Player_Hero" || collision.gameObject.name == "Player_Bandit" || collision.gameObject.name == "Player_Cemetry_Hero")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
}
