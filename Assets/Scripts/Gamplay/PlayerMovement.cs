using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    void Update()
    {
        //going
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0, 5);
            
        }
            //stopping
            if (Input.GetKeyUp(KeyCode.W))
            {
                rb.velocity = new Vector2(0, 0);
            }
        //going
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0, -5);
        }
            //stopping
            if (Input.GetKeyUp(KeyCode.S))
            {
                rb.velocity = new Vector2(0, 0);
            }
        //going
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5, 0);
        }
            //stopping
            if (Input.GetKeyUp(KeyCode.A))
            {
                rb.velocity = new Vector2(0, 0);
            }
        //going
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5, 0);
        }
            //stopping
            if (Input.GetKeyUp(KeyCode.D))
            {
                rb.velocity = new Vector2(0, 0);
            }
    }
}
