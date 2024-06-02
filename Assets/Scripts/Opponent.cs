using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    private int speed;
    public Rigidbody2D ball;
    public Main main;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(main.PlayerScore > 3)
        {
            speed = main.PlayerScore;
        }
        RaycastHit2D hit = Physics2D.Raycast(new Vector2((float)(ball.position.x + 0.3), ball.position.y), ball.velocity);

        if (hit.collider != null && hit.collider.gameObject.name == "Opponent")
        {
            Debug.Log(hit.collider.gameObject.name);
            if(hit.point.y < GetComponent<Rigidbody2D>().position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            }
            else if(hit.point.y > GetComponent<Rigidbody2D>().position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }
    }
}
