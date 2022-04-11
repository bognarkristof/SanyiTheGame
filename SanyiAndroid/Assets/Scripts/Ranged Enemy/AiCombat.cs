using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCombat : MonoBehaviour
{
    [SerializeField]public GameObject player; //player a kiválasztott dolog, ami miatt megáll az enemy (public legyen)

    [SerializeField]public GameObject projectile; //kiválaszott projectile (public legyen)
    [SerializeField] public LayerMask mask; //kell a player layer, hogy felismerje a playert és minden más collidert ignoráljon


    [SerializeField] public float visionDistance; //a látótávolság, amiben meglát az enemy (public legyen)
   
    [SerializeField] public float startTimeBtwShots; // lövések közötti idõ (public legyen)
    private float timeBtwShots; //azért kell 2, mert az egyik másodpercenként megy le, míg eléri a nullát, majd a másik idõhöz igazodva visszaáll és újrakezdõdik a számolás
    
    

    enum FightingState { backtopatrol, reload, shoot } //state-ek tárolása: nem látja a playert és újra járkál || lövések közötti idõ || lövés

    // Start is called before the first frame update
    private void Start()
    {
        timeBtwShots = startTimeBtwShots; //idõ és idõvisszaállító beállítása
    }

    // Update is called once per frame
    private void Update()
    {
        //enemy és player közötti rész
        Vector2 targetVector = (player.transform.position - transform.position).normalized;

        

        //ha a player az enemy elõtt van
        if(Vector2.Dot(-transform.right, targetVector)> .5)
        {
            
            //kiküld egy sugarat a visionDistance-ig
            RaycastHit2D hit;

            hit = Physics2D.Raycast(transform.position, targetVector, visionDistance, mask);

            
            //ha benne található a player, akkor az AiPatrol script leáll és el kezd projectile-okat idézni
            if(hit.collider.gameObject == player)
            {
                
                if (timeBtwShots <=0) //ha a számoló 0-ra ér, akkor a state shoot-ra vált és az enemy lõ
                {

                    FightingState state;
                    state = FightingState.shoot;
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
                else //a lövések közötti idõ megy le, és a state reload-ra vált
                {
                    FightingState state;
                    state = FightingState.reload;
                    timeBtwShots -= Time.deltaTime;
                }



                this.GetComponent<AiPatrol>().enabled = false;
            }

            //ha nincs benne a player, akkor a patrol script elindul újra (az else nem mûködött) , a state patrol-ra vált
            if (player.transform.position.x != hit.distance )
            {
                
                
                    this.GetComponent<AiPatrol>().enabled = true;
                    FightingState state;
                    state = FightingState.backtopatrol;
                    
                
                
                
                    
                
            }


        }
        //ha a player az enemy háta mögött van, akkor a patrol script elindul újra, a state patrol-ra vált
        else
        {
            
            this.GetComponent<AiPatrol>().enabled = true;
            FightingState state;
            state = FightingState.backtopatrol;

        }




    }












}
