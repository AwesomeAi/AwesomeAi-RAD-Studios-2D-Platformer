using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{

    //Serialized Fields
    [SerializeField] private LayerMask surface; //checks for anything in the ground layer

    //Public variables
    public float jumpVeloctiy; 
    public float moveSpd; //max move speed

    public float airMobility;

    //Private variables

    // counts wall jumps to avoid character jumping on wall infinitely
    private int wallJumpsRight = 0;
    private int wallJumpsLeft = 0;
   
    //animation counters


    //creates reference varible for compnenets
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private AnimeShuns a;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        bc2d = transform.GetComponent<BoxCollider2D>();
        a = transform.GetComponent<AnimeShuns>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGrounded()) // checks if player is grounded
        {
            jumping();
            a.jumpReset();
        }
        

        horizontal();
    }


    //runs jump code
    private void jumping()
    {
        //Checks for keys
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            a.fullJump();
            rb2d.velocity = Vector2.up * jumpVeloctiy;
        }

    }

    private void horizontal()
    {
        float currentSpd = moveSpd;
        
        //moving right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            if (isGrounded())
            {
                rb2d.velocity = new Vector2(moveSpd, rb2d.velocity.y);
                a.direction("right");
            }

            else
            {
                rb2d.velocity += new Vector2(moveSpd * airMobility * Time.deltaTime, 0);
                rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -moveSpd, +moveSpd), rb2d.velocity.y);
            }
            
        }

        //moving left
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (isGrounded())
            {
                rb2d.velocity = new Vector2(-moveSpd, rb2d.velocity.y);
                a.direction("left");
                a.run();
            }

            else
            {
                rb2d.velocity += new Vector2(-moveSpd * airMobility * Time.deltaTime, 0);
                rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -moveSpd, +moveSpd), rb2d.velocity.y);
                a.fullJump();
            }
        }

        //stand still
        else if (isGrounded())
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            if(0 == rb2d.velocity.x)
            {
                a.idle(true);
            }
        }
        
    }


    private bool isGrounded()
    {
        RaycastHit2D rh2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, .1f, surface);
        Debug.Log(rh2d.collider);

        wallJumpsRight = 0;
        wallJumpsLeft = 0;

        return rh2d.collider != null;
    }

    private bool onWallRight()
    {
        RaycastHit2D rh2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.right, .1f, surface);
        Debug.Log(rh2d.collider);

        if (wallJumpsRight < 1)
        {
            wallJumpsLeft = 0;
            wallJumpsRight += 1;
            return rh2d.collider != null;
        }

        return false;
    }

    private bool onWallLeft()
    {
        RaycastHit2D rh2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.left, .1f, surface);
        Debug.Log(rh2d.collider);

        if (wallJumpsLeft < 1)
        {
            wallJumpsRight = 0;
            wallJumpsLeft += 1;
            return rh2d.collider != null;
        }

        return false;
    }
}





