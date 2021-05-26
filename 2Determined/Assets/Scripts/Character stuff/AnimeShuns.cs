using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeShuns : MonoBehaviour
{
    Animator animator;
    SpriteRenderer spr;

    //animation counters
    int jumpToFall = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

   public void idle(bool isIdle)
    {
        if(isIdle)
        {
            animator.Play("Judas Animation");
        }
    }

    public void direction(string direction)
    {
        if (direction.Equals("right"))
        {
            spr.flipX = false;
            
        }
        if(direction.Equals("left"))
        {
            spr.flipX = true;
        }
    }

    public void run()
    {
        animator.Play("Judas run");
    }

    public void jump()
    {
        animator.Play("Judas jump");
    }

    public void falling()
    {
        animator.Play("Judas midair");
    }

    public void wallJump()
    {
        animator.Play("jump from wall");
    }

    public void onWall()
    {
        animator.Play("wall");
    }

    public void fullJump()
    {
       if (jumpToFall == 0)
        {
            jump();
            jumpToFall++;
        }
       else
        {
            falling();
        }
    }

    public void jumpReset()
    {
        jumpToFall = 0;
    }

}