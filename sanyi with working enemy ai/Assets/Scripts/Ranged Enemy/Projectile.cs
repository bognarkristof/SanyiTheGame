using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]public float speed; //l�ved�k sebess�ge (public legyen)
    [SerializeField]public float travelTime; //l�ved�k �ll�that� l�v�st�vols�ga (public legyen) ez el kezd 0-ra menni, amikor l�trej�n, mikor el�ri a null�t, akkor a l�ved�k elt�nik �s a sz�ml�l� vissza�ll az eredeti sz�mra
    private float theTravelTime; //l�ved�k eredeti l�v�st�vols�ga
    private float origin; //l�ved�k eredeti megjelen�se az x tengelyen (kell, hogy a l�v�st�vols�got meghosszabb�tsam)
    
    
    private Vector2 target; //player helye az x helyen
    private GameObject player; //player megtal�l�s�hoz sz�ks�ges


    // Start is called before the first frame update

    enum ProjState { fly, dissappear }
    private void Start()
    {
        theTravelTime = travelTime; //eredeti l�v�st�vols�g be�ll�t�sa


        player = GameObject.FindWithTag("Player"); //player taggel megtal�lja a playert
        target = new Vector2(player.transform.position.x, transform.position.y); //player hely�re megy a l�ved�k
        origin = transform.position.x;
    }

    // Update is called once per frame
    private void Update()
    {

        ProjState state;
        state = ProjState.fly; //a l�ved�k a leveg�ben rep�l
        transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime); //l�ved�k mozogjon a c�l hely�re 

        if(transform.position.x> origin)
        {
            target = new Vector2(99999, transform.position.y); //menjen tov�bb a l�ved�k
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        }
        else if( transform.position.x < origin)
        {
            target = new Vector2(-99999, transform.position.y); //menjen tov�bb a l�ved�k
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        }



        if (travelTime <= 0) //megadott id� m�lva a l�ved�k elt�nik
        {
            DestroyProjectile();
            travelTime = theTravelTime;
        }
        else
        {
            travelTime -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) //ha a playerhez �r a l�ved�k, akkor elt�nik (a l�ved�k)
    {
        if(other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }


    private void DestroyProjectile() //l�ved�k elt�ntet�se 
    {
        ProjState state;
        state = ProjState.dissappear; //a l�ved�k elt�nik
        Destroy(gameObject);
    }


}
