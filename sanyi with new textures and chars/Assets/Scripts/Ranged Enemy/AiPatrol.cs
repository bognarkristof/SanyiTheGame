using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
   

    [SerializeField] private float theWalkSpeed; //ez azért kell, hogy a walk speedet visszaállítsuk, ezt kell állítani
    [SerializeField]  public float theWaitTime; //ezt kell állítani, hogy a várakozó idõt állítsuk
    [SerializeField] private float raydetectionDistance; //a földet nézõ sugár hossza (2.8 alatt nem érzékeli a földet)

    private float walkSpeed; //enemy gyorsasága, ezt nem kell állítani
    private float waitTime; //ez megy le, amikor a várakozó idõt nézzük

    private bool movingLeft = true; //jobbra vagy balra megy

    public Transform groundDetection; //a game object, amibõl jön ki a jelzõsugár (public legyen)
    private Rigidbody2D rigidbody;
    private BoxCollider2D bodycollider;





    enum MovementState { movingright, movingleft, idle}






    // Start is called before the first frame update
    private void Start()
    {
        waitTime = theWaitTime; //alap várakozó idõ beállítása
        walkSpeed = theWalkSpeed; //alap sebesség beállítása

       
       

    }

    // Update is called once per frame
    private void Update()
    {

        Moving();

        //a game obejctbõl kezdje el sugározni a jelzõsugarat
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,raydetectionDistance); 
         if(groundInfo.collider == false) //ha nem észlel földet és balra halad, akkor fordítsa meg a karaktert
        {
            if(movingLeft == true)
            {
                StartMovingRight();    
            }
            else //ha jobbra halad, akkor kezdjen el balra haladni
            {

                StartMovingLeft();
                
            }
        }

    }


    private IEnumerator wait()
    {
        yield return new WaitForSeconds(waitTime);
    }

   private void Moving() //alapból balra kezd el mozogni, ezért a state-et balra mozgásra állítom
    {
        MovementState state;
        state = MovementState.movingleft;
        transform.Translate(Vector2.right * -walkSpeed * Time.deltaTime); //kezdjen el balra mozogni
    }


    private void Idle() //megáll és a state-et idle-re állítom
    {
        MovementState state;
        state = MovementState.idle;
        this.walkSpeed = 0; //álljon meg
    }


    private void StartMovingAgain() //erre nem hiszem, hogy kell state, mert ez mehet jobbra is meg balra is
    {
        this.walkSpeed = theWalkSpeed;
    }


    private void StartMovingLeft() //balra megy és a state-et bal oldali mozgásra állítom
    {
        Idle();
        //számoljon vissza, és ha megvolt, akkor induljon el a másik irányba
        if (waitTime <= 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            movingLeft = true;
            waitTime = theWaitTime;
            StartMovingAgain();
            MovementState state;
            state = MovementState.movingleft;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }


    private void StartMovingRight() //jobb oldara megy és a state-et jobb oldali mozgásra állítom
    {
        Idle();
        //számoljon vissza, és ha megvolt, akkor induljon el a másik irányba
        if (waitTime <= 0)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            movingLeft = false;
            waitTime = theWaitTime;
            StartMovingAgain();
            MovementState state;
            state = MovementState.movingright;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }



}
