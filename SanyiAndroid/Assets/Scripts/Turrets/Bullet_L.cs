using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_L : MonoBehaviour
{
    [SerializeField] private float speed; //lövedék sebessége 
    [SerializeField] private float travelTime; //lövedék állítható lövéstávolsága
    private float downTravelTime; //ezzel kell számolni a lövési idõt
    private GameObject player; //player megtalálásához szükséges
    
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

    private void OnTriggerEnter2D(Collider2D other) //ha a playerhez ér a tûz akkor a player meghal
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<playerlife>().Die();
            DestroyProjectile();
            player.GetComponent<playerlife>().Invoke("RestartLevel", 2f);


        }

        

    }

    private void DestroyProjectile() //lövedék eltüntetése 
    {
        
        Destroy(gameObject);
    }

    private void Fly()
    {


        Vector2 target = new Vector2(-99999, transform.position.y); //menjen tovább a lövedék
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (downTravelTime <= 0 ) //megadott idõ múlva a lövedék eltûnik
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
