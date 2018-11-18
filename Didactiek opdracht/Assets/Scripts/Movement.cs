using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb; //Set riggidbody
    Animator anim; //set animation
    float dirX, moveSpeed = 5f; //set movementspeed
    int healthPoints = 3; //set Healthpoint (will be used later on)
    bool isHurting, isDead; //set you are dead or hurt (will be used later on)
    bool facingRight = true; //Check the facing
    Vector3 localScale;
    public GameObject question;
    public QuestionManager questionManager;

    public bool grounded; //check if grounded
    float groundRadius = .2f; //ground object radius for groundcheck
    public LayerMask ground; //layermask which layers are ground
    public Transform groundCheck; //object under the player for the groundcheck

    // Use this for initialization
    void Start()
    {
        //instantiating all objects
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale; //check forthe player facing
    }

    // Update is called once per frame
    void Update()
    {
        //add force to player if the player presses space
        if (Input.GetButtonDown("Jump") && !isDead && rb.velocity.y == 0 && grounded)
            rb.AddForce(Vector2.up * 600f);

        SetAnimationState();//set the state of the animation

        // is for dead animation (will be used later on)
        if (!isDead)
            dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        //check for grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, ground);
        if (!isHurting)//check for hurting, player will move in the opposite if being hit by something(will be used later on)
            rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void SetAnimationState()
    {
        if (dirX == 0) //Idle animation when movement is 0 
        {
            anim.SetBool("isWalking", false);
        }

        if (rb.velocity.y == 0 && grounded)//Idle animation when velocity = 0 and = grounded
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (Mathf.Abs(dirX) == 5 && rb.velocity.y == 0 && grounded) //Running animation when movement = 5 and no falling velocity and grounded
            anim.SetBool("isWalking", true);

        if (rb.velocity.y > 0) // Jumping animation when velocity > 0
            anim.SetBool("isJumping", true);

        if (rb.velocity.y < 0)//falling animation when velocity < 0
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }

    //facing check
    void CheckWhereToFace()
    {
        if (dirX > 0) //movement is + face right
            facingRight = true;
        else if (dirX < 0) //movement - face left
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    // Not in use right now because there are no enemies or damage object in the game yet
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Damage")
        {
            healthPoints -= 1;
        }

        if (col.tag == "Damage" && healthPoints > 0)
        {
            anim.SetTrigger("isHurt");
            StartCoroutine("Hurt");
        }
        if(col.tag == "Damage" && healthPoints < 0)
        {
            dirX = 0;
            isDead = true;
            anim.SetTrigger("isDead");
        }
        if (col.gameObject == question)
        {
            Debug.Log("question");
            questionManager.Pause();
        }
    }
    // Not in use right now because there are no enemies or damage object in the game yet
    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }

}
