using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float xSpeed;
    private float ySpeed;
    public Rigidbody2D player;
    public Rigidbody2D opponent;

    private bool playerScored;
    private bool opponentScored;

    public bool PlayerScored
    {
        get { return playerScored; }
    }

    public bool OpponentScored
    {
        get { return opponentScored; }
    }

    //public Main main;

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = -3;
        ySpeed = 3;
        playerScored = false;
        opponentScored = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(xSpeed, ySpeed);
    }

    public void Reset()
    {
        GetComponent<Rigidbody2D>().position = new Vector2(0, 1);
        ySpeed = 3;
        if (playerScored)
        {
            xSpeed = 3;
            playerScored = false;
        }
        else
        {
            xSpeed = -3;
            opponentScored = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "wall")
        {
            ySpeed *= -1;
        }
        if (col.gameObject.tag == "player")
        {
            xSpeed *= -1;
            if (xSpeed > 0)
            {
                xSpeed += 0.5f;
            }
            else
            {
                xSpeed -= 0.5f;
            }
            //Debug.Log(xSpeed);
        }

        if(col.gameObject.name == "Player1")
        {
            //Debug.Log(player.velocity.y);
            if(player.velocity.y != 0)
            {
                ySpeed += player.velocity.y / 2;
            }
            //Debug.Log(ySpeed);
        }

        if (col.gameObject.name == "Opponent")
        {
            if (opponent.velocity.y != 0)
            {
                ySpeed += opponent.velocity.y / 2;
            }
        }

        if(col.gameObject.name == "leftGoal")
        {
            //main.OpponentScore = main.OpponentScore + 1;
            opponentScored = true;
            //Reset();
        }

        if(col.gameObject.name == "rightGoal")
        {
            //main.PlayerScore = main.PlayerScore + 1;
            playerScored = true;
            //Reset();
        }
    }
}
