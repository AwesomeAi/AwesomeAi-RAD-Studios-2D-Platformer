using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertical : MonoBehaviour
{
    public float jumpVeloctiy;
    public float moveSpd;

    public float airMobility;


    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        bc2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        jumping();
        horizontal();
    }


    //runs jump code
    private void jumping()
    {
        //Checks for keys
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpVeloctiy;
        }

    }

    private void horizontal()
    {
        float currentSpd = moveSpd;
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(moveSpd, rb2d.velocity.y);
        }

        else
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb2d.velocity = new Vector2(-moveSpd, rb2d.velocity.y);
            }

            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
        }
    }
}




