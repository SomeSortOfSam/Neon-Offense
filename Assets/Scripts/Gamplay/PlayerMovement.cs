using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : Rebounder
{
    Rigidbody2D ridgidBody;
    public float speed = 5;

    private void Start()
    {
        ridgidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ridgidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
    }
}
