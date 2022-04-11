using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrActivate : MonoBehaviour
{
    [SerializeField] private float timeBtwSpits; // l�v�sek k�z�tti id� 
    private float downTimeBtwSpits; //az�rt kell 2, mert az egyik m�sodpercenk�nt megy le, m�g el�ri a null�t, majd a m�sik id�h�z igazodva vissza�ll �s �jrakezd�dik a sz�mol�s
    [SerializeField] private float delayTimeAtStart; //amikor a level kezd�dik, ennyi m�sodperc ut�n indul el a csapda
    [SerializeField] private float fireDuration; //a t�z id�tartama
    private float downFireDuration; //a t�z id�tartama, ami le megy null�ra
    [SerializeField] private GameObject capsule; //kell
    private GameObject player; //player megtal�l�s�hoz sz�ks�ges
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
