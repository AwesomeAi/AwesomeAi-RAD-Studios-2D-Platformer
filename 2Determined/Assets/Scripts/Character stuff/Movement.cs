using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Movement : MonoBehaviour
{

    //Serialized Fields
    [SerializeField] private LayerMask surface; //checks for anything in the ground layer

    //Public variables
    [Header ("horizontal movement")]
    public float moveSpd; //max move speed

    [Header ("arial movement")]
    public float jumpVeloctiy; 
    public float airMobility;

    [Header ("wall movement")]
    public float wallSlideSpd;

    public float wallDistance;

    public float wallJumpX;
    public float wallJumpY;

    RaycastHit2D WallCheckHitR;
    RaycastHit2D WallCheckHitL;

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

        if (isGrounded()) // checks if player is grounded
        {
            jumping();
        }        
   
    }

    void FixedUpdate()
    {
        wallMove();
        horizontal();
    }


    //runs jump code
    private void jumping()
    {
        //Checks for keys
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            a.falling();

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
                a.run();
            }

            else
            {
                rb2d.velocity += new Vector2(moveSpd * airMobility * Time.deltaTime, 0);
                rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -moveSpd, +moveSpd), rb2d.velocity.y);
                if ((onWallLeft() == false) || (onWallRight() == false))
                {
                    a.falling();
                }
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
                if ((onWallLeft() == false) || (onWallRight() == false))
                {
                    a.falling();
                }
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
        RaycastHit2D rh2d = Physics2D.BoxCast(bc2d.bounds.center, bc2d.bounds.size, 0f, Vector2.down, 1f, surface);

        return rh2d.collider != null;
    }

    private bool onWallRight()
    {
        WallCheckHitR = Physics2D.Raycast(transform.position, new Vector2(wallDistance, 0f), wallDistance, surface);
        Debug.DrawRay(transform.Position, new Vector(wallDistance, 0, Color.Red))

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            return true;
        }

        return false;

    }

    private bool onWallLeft()
    {
        WallCheckHitL = Physics2D.Raycast(transform.position, new Vector2(-wallDistance, 0f), -wallDistance, surface);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            return true;
        }

        return false;

    }


    private void wallmove()
    {
       if(onWallRight)
       {
            if(wallCheckHitR && isGrounded()!)
            {
                rb2d.velocity = Vector2.down * wallSlideSpd;
                a.direction("left");
                a.onwall();
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    wallJump("left");
                }
            }  
       }
       
       if(onWallLeft)
       {
            if(wallCheckHitL && isGrounded()!)
            {
                rb2d.velocity = Vector2.down * wallSlideSpd;
                a.direction("right");
                a.onwall();
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    wallJump("right");
                }
            }
    }   

    private void walljump(string direction)
    {

        
        if (direction.Equals("right"))
        {
            rb2d.velocity = Vector2.up * wallJumpY;
            rb2d.velocity = Vector2.left * wallJumpX;
            a.falling();
        }

        if (direction.Equals("left"))
        {
            rb2d.velocity = Vector2.up * wallJumpY;
            rb2d.velocity = Vector2.left * (-wallJumpX);
            a.falling();
        }
        
    }

}
