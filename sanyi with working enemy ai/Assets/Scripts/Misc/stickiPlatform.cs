using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickiPlatform : MonoBehaviour
{

    private void OnCollisionExit2D(Collision2D collision)//el�z� fuggv�ny ellent�te, ha leugrik a platformt�l akkor elt�nik a parent tulajdons�g �gy nem mozognak egy�tt
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Player_Hero" || collision.gameObject.name == "Player_Bandit" || collision.gameObject.name == "Player_Cemetry_Hero")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//ha a player objektum hozz��r a platformhoz akkor vele fog mozigni
    {
        if (collision.gameObject.name == "Player" || collision.gameObject.name == "Player_Hero" || collision.gameObject.name == "Player_Bandit" || collision.gameObject.name == "Player_Cemetry_Hero")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
}
