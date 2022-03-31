using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrActivate : MonoBehaviour
{
    [SerializeField] private float timeBtwSpits; // lövések közötti idõ 
    private float downTimeBtwSpits; //azért kell 2, mert az egyik másodpercenként megy le, míg eléri a nullát, majd a másik idõhöz igazodva visszaáll és újrakezdõdik a számolás
    [SerializeField] private float delayTimeAtStart; //amikor a level kezdõdik, ennyi másodperc után indul el a csapda
    [SerializeField] private float fireDuration; //a tûz idõtartama
    private float downFireDuration; //a tûz idõtartama, ami le megy nullára
    [SerializeField] private GameObject capsule; //kell
    private GameObject player; //player megtalálásához szükséges
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        downTimeBtwSpits = delayTimeAtStart;
        downFireDuration = fireDuration;
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        Activate();
    }

    [System.Obsolete]
    private void Activate()
    {
        if(downTimeBtwSpits <=0 )
        {
            
            if(downFireDuration <= 0)
            {
                
                Deactivate();
                
            }
            else
            {
                capsule.active = true;
                downFireDuration -= Time.deltaTime;
                anim.SetBool("IsActive", true);
                
            }



        }
        else if(downTimeBtwSpits > 0)
        {
            downFireDuration = fireDuration;
            downTimeBtwSpits -= Time.deltaTime;

        }



    }

    [System.Obsolete]
    private void Deactivate()
    {
        capsule.active = false;
        downTimeBtwSpits = timeBtwSpits;
        anim.SetBool("IsActive", false);
    }




}
