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
            direction = Player.instance.transform.position - transform.position;
            direction.Normalize();
        }
        rigidbody.velocity = direction;
    }
}
