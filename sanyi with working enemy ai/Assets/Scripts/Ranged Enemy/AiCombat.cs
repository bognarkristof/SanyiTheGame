using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCombat : MonoBehaviour
{
    [SerializeField]public GameObject player; //player a kiv�lasztott dolog, ami miatt meg�ll az enemy (public legyen)

    [SerializeField]public GameObject projectile; //kiv�laszott projectile (public legyen)
    [SerializeField] public LayerMask mask; //kell a player layer, hogy felismerje a playert �s minden m�s collidert ignor�ljon


    [SerializeField] public float visionDistance; //a l�t�t�vols�g, amiben megl�t az enemy (public legyen)
   
    [SerializeField] public float startTimeBtwShots; // l�v�sek k�z�tti id� (public legyen)
    private float timeBtwShots; //az�rt kell 2, mert az egyik m�sodpercenk�nt megy le, m�g el�ri a null�t, majd a m�sik id�h�z igazodva vissza�ll �s �jrakezd�dik a sz�mol�s
    
    

    enum FightingState { backtopatrol, reload, shoot } //state-ek t�rol�sa: nem l�tja a playert �s �jra j�rk�l || l�v�sek k�z�tti id� || l�v�s

    // Start is called before the first frame update
    private void Start()
    {
        timeBtwShots = startTimeBtwShots; //id� �s id�vissza�ll�t� be�ll�t�sa
    }

    // Update is called once per frame
    private void Update()
    {
        //enemy �s player k�z�tti r�sz
        Vector2 targetVector = (player.transform.position - transform.position).normalized;

        

        //ha a player az enemy el�tt van
        if(Vector2.Dot(-transform.right, targetVector)> .5)
        {
            
            //kik�ld egy sugarat a visionDistance-ig
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, targetVector, visionDistance, mask);

            
            //ha benne tal�lhat� a player, akkor az AiPatrol script le�ll �s el kezd projectile-okat id�zni
            if(hit.collider.gameObject == player)
            {
                
                if (timeBtwShots <=0) //ha a sz�mol� 0-ra �r, akkor a state shoot-ra v�lt �s az enemy l�
                {

                    FightingState state;
                    state = FightingState.shoot;
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
                else //a l�v�sek k�z�tti id� megy le, �s a state reload-ra v�lt
                {
                    FightingState state;
                    state = FightingState.reload;
                    timeBtwShots -= Time.deltaTime;
                }



                this.GetComponent<AiPatrol>().enabled = false;
            }

            //ha nincs benne a player, akkor a patrol script elindul �jra (az else nem m�k�d�tt) , a state patrol-ra v�lt
            if (player.transform.position.x != hit.distance )
            {
                
                
                    this.GetComponent<AiPatrol>().enabled = true;
                    FightingState state;
                    state = FightingState.backtopatrol;
                    
                
                
                
                    
                
            }


        }
        //ha a player az enemy h�ta m�g�tt van, akkor a patrol script elindul �jra, a state patrol-ra v�lt
        else
        {
            
            this.GetComponent<AiPatrol>().enabled = true;
            FightingState state;
            state = FightingState.backtopatrol;

        }




    }












}
