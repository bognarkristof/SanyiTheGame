using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
   

    [SerializeField] private float theWalkSpeed; //ez az�rt kell, hogy a walk speedet vissza�ll�tsuk, ezt kell �ll�tani
    [SerializeField]  public float theWaitTime; //ezt kell �ll�tani, hogy a v�rakoz� id�t �ll�tsuk
    [SerializeField] private float raydetectionDistance; //a f�ldet n�z� sug�r hossza (2.8 alatt nem �rz�keli a f�ldet)

    private float walkSpeed; //enemy gyorsas�ga, ezt nem kell �ll�tani
    private float waitTime; //ez megy le, amikor a v�rakoz� id�t n�zz�k

    private bool movingLeft = true; //jobbra vagy balra megy

    public Transform groundDetection; //a game object, amib�l j�n ki a jelz�sug�r (public legyen)
    private Rigidbody2D rigidbody;
    private BoxCollider2D bodycollider;





    enum MovementState { movingright, movingleft, idle}






    // Start is called before the first frame update
    private void Start()
    {
        waitTime = theWaitTime; //alap v�rakoz� id� be�ll�t�sa
        walkSpeed = theWalkSpeed; //alap sebess�g be�ll�t�sa

       
       

    }

    // Update is called once per frame
    private void Update()
    {

        Moving();

        //a game obejctb�l kezdje el sug�rozni a jelz�sugarat
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position,Vector2.down,raydetectionDistance); 
         if(groundInfo.collider == false) //ha nem �szlel f�ldet �s balra halad, akkor ford�tsa meg a karaktert
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

   private void Moving() //alapb�l balra kezd el mozogni, ez�rt a state-et balra mozg�sra �ll�tom
    {
        MovementState state;
        state = MovementState.movingleft;
        transform.Translate(Vector2.right * -walkSpeed * Time.deltaTime); //kezdjen el balra mozogni
    }


    private void Idle() //meg�ll �s a state-et idle-re �ll�tom
    {
        MovementState state;
        state = MovementState.idle;
        this.walkSpeed = 0; //�lljon meg
    }


    private void StartMovingAgain() //erre nem hiszem, hogy kell state, mert ez mehet jobbra is meg balra is
    {
        this.walkSpeed = theWalkSpeed;
    }


    private void StartMovingLeft() //balra megy �s a state-et bal oldali mozg�sra �ll�tom
    {
        Idle();
        //sz�moljon vissza, �s ha megvolt, akkor induljon el a m�sik ir�nyba
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


    private void StartMovingRight() //jobb oldara megy �s a state-et jobb oldali mozg�sra �ll�tom
    {
        Idle();
        //sz�moljon vissza, �s ha megvolt, akkor induljon el a m�sik ir�nyba
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
