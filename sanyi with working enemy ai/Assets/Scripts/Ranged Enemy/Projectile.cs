using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]public float speed; //lövedék sebessége (public legyen)
    [SerializeField]public float travelTime; //lövedék állítható lövéstávolsága (public legyen) ez el kezd 0-ra menni, amikor létrejön, mikor eléri a nullát, akkor a lövedék eltûnik és a számláló visszaáll az eredeti számra
    private float theTravelTime; //lövedék eredeti lövéstávolsága
    private float origin; //lövedék eredeti megjelenése az x tengelyen (kell, hogy a lövéstávolságot meghosszabbítsam)
    
    
    private Vector2 target; //player helye az x helyen
    private GameObject player; //player megtalálásához szükséges


    // Start is called before the first frame update

    enum ProjState { fly, dissappear }
    private void Start()
    {
        theTravelTime = travelTime; //eredeti lövéstávolság beállítása


        player = GameObject.FindWithTag("Player"); //player taggel megtalálja a playert
        target = new Vector2(player.transform.position.x, transform.position.y); //player helyére megy a lövedék
        origin = transform.position.x;
    }

    // Update is called once per frame
    private void Update()
    {

        ProjState state;
        state = ProjState.fly; //a lövedék a levegõben repül
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime); //lövedék mozogjon a cél helyére 

        if(transform.position.x> origin)
        {
            target = new Vector2(99999, transform.position.y); //menjen tovább a lövedék
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        }
        else if( transform.position.x < origin)
        {
            target = new Vector2(-99999, transform.position.y); //menjen tovább a lövedék
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        }



        if (travelTime <= 0) //megadott idõ múlva a lövedék eltûnik
        {
            DestroyProjectile();
            travelTime = theTravelTime;
        }
        else
        {
            travelTime -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) //ha a playerhez ér a lövedék, akkor eltûnik (a lövedék)
    {
        if(other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }


    private void DestroyProjectile() //lövedék eltüntetése 
    {
        ProjState state;
        state = ProjState.dissappear; //a lövedék eltûnik
        Destroy(gameObject);
    }


}
