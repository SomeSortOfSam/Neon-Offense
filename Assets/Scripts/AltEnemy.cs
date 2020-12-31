using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltEnemy : Enemy
{
    Vector2 direction;
    public override void Charge()
    {
        if(direction != Vector2.zero)
        {
            direction = FindObjectOfType<Player>().transform.position - transform.position;
            direction.Normalize();
        }
        bool v = transform.position.y - yPos > .5f;
        rigidbody.velocity = v ? direction : Vector2.zero;
        if (!v)
        {
            chargeing = false;
            direction = Vector2.zero;
        }
    }
}
