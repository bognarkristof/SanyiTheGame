using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_L : MonoBehaviour
{
    [SerializeField] private float speed; //l�ved�k sebess�ge 
    [SerializeField] private float travelTime; //l�ved�k �ll�that� l�v�st�vols�ga
    private float downTravelTime; //ezzel kell sz�molni a l�v�si id�t
    private GameObject player; //player megtal�l�s�hoz sz�ks�ges
    
    void Start()
    {
        downTravelTime = travelTime;
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Fly();
    }

    private void OnTriggerEnter2D(Collider2D other) //ha a playerhez �r a t�z akkor a player meghal
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<playerlife>().Die();
            DestroyProjectile();
            player.GetComponent<playerlife>().Invoke("RestartLevel", 2f);


        }

        

    }

    private void DestroyProjectile() //l�ved�k elt�ntet�se 
    {
        
        Destroy(gameObject);
    }

    private void Fly()
    {


        Vector2 target = new Vector2(-99999, transform.position.y); //menjen tov�bb a l�ved�k
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (downTravelTime <= 0 ) //megadott id� m�lva a l�ved�k elt�nik
        {
            DestroyProjectile();
            downTravelTime = travelTime;
        }
        else
        {
            downTravelTime -= Time.deltaTime;
        }

        
        


    }
}
