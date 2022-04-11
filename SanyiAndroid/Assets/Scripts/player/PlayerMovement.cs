using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{


    private Rigidbody2D rb; 
    private Animator anim;
    private SpriteRenderer sp;
    private BoxCollider2D coll;
    public Joystick stick;
    public Joystick jumpStick;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpSound;
    float dirX = 0;
    private float moveSpeed;//mozgási sebesség
    private float jumpForce; //ugrás erõssége

    private enum MovementState { idle, running, jumping, falling } //ez tárolja a jelenlegi helyzetünket


    // Start is called before the first frame update
    private void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();

        Debug.Log(dirX);
        moveSpeed = 0f;
        jumpForce = 20f;
    }
    
        
    

    // Update is called once per frame
    private void Update()
    {

        
        if (stick.Horizontal >= .2f)
        {
            moveSpeed = stick.Horizontal * 15;

            dirX = moveSpeed;
        }
        else if (stick.Horizontal <= .2f)
        {
            moveSpeed = -stick.Horizontal * 15;

            dirX = -moveSpeed;
        }
        else
        {
            dirX = 0f;
        }



        if(jumpStick.Vertical >= .2f)
        {
            Jump();
        }





        rb.velocity = new Vector2(dirX, rb.velocity.y);
        AnimationState();
    }


    public void Jump()
    {
        if (JumpOrNot())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //Y tengelyen történõ pozícióváltozás
            jumpSound.Play();
        }
    }
  
    private void AnimationState()
    {
        MovementState state;
        if (dirX > .2f)
        {
            state = MovementState.running;
            
            sp.flipX = false;
        }
        else if (dirX < -.2f)
        {

            state = MovementState.running;
           
            sp.flipX = true;
        }
        else
        {   
            
            state = MovementState.idle;
        }

        if (rb.velocity.y > .2f)
        {
            state = MovementState.jumping;
            
        }
        else if (rb.velocity.y < -.2f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool JumpOrNot()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .2f, jumpableGround);
    }


}
