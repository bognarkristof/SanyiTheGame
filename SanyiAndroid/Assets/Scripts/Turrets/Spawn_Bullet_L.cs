using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Bullet_L : MonoBehaviour
{
    [SerializeField] private float timeBtwShots; // lövések közötti idõ 
     private float downTimeBtwShots; //azért kell 2, mert az egyik másodpercenként megy le, míg eléri a nullát, majd a másik idõhöz igazodva visszaáll és újrakezdõdik a számolás
    [SerializeField] private GameObject bullet; //kiválaszott projectile 
    // Update is called once per frame
    private void Start()
    {
        downTimeBtwShots = timeBtwShots;
        
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (downTimeBtwShots <= 0) //ha a számoló 0-ra ér, akkor az enemy lõ
        {

            
            
            Instantiate(bullet, transform.position, Quaternion.identity);
            downTimeBtwShots = timeBtwShots;
        }
        else //a lövések közötti idõ megy le
        {
            
            
            downTimeBtwShots -= Time.deltaTime;
        }
    }




}
