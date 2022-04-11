using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Bullet_L : MonoBehaviour
{
    [SerializeField] private float timeBtwShots; // l�v�sek k�z�tti id� 
     private float downTimeBtwShots; //az�rt kell 2, mert az egyik m�sodpercenk�nt megy le, m�g el�ri a null�t, majd a m�sik id�h�z igazodva vissza�ll �s �jrakezd�dik a sz�mol�s
    [SerializeField] private GameObject bullet; //kiv�laszott projectile 
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
        if (downTimeBtwShots <= 0) //ha a sz�mol� 0-ra �r, akkor az enemy l�
        {

            
            
            Instantiate(bullet, transform.position, Quaternion.identity);
            downTimeBtwShots = timeBtwShots;
        }
        else //a l�v�sek k�z�tti id� megy le
        {
            
            
            downTimeBtwShots -= Time.deltaTime;
        }
    }




}
