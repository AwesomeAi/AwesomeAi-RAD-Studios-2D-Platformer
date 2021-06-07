using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    public LevelManager levelManager;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("player"))
        {
            Debug.Log("You win");
            levelManager.loadLevel("Win");
        }
    }
}

