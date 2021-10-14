using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb; 
    private Animator anim;
    private SpriteRenderer sp;
    private BoxCollider2D coll;



    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float jumpForce = 20f; //ugrás erõssége
    [SerializeField] private float moveSpeed = 12f;//mozgási sebesség
     private float dirX = 0f; //x tengelyen lévõ pozíció, Raw->ezzel nincs csúszás mikor abbahagyjuk a mozgás

    private enum MovementState { idle, running, jumping, falling } //ez tárolja a jelenlegi helyzetünket

    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX*moveSpeed, rb.velocity.y); //X tengelyen történõ pozícióváltozás


        if (Input.GetButtonDown("Jump") && JumpOrNot())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //Y tengelyen történõ pozícióváltozás
            jumpSound.Play();
        }
        AnimationState();
    }

    private void AnimationState()
    {
        MovementState state;
        if (dirX > .1f)
        {
            state = MovementState.running;
            sp.flipX = false;
        }
        else if (dirX < -.1f)
        {
            state = MovementState.running;
            sp.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
            
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool JumpOrNot()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }


}
