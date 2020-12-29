using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerBullet : Bullet
{
    public Rigidbody2D rb;

    void Start()
    {
        this.friendly = true;
        rb.velocity = new Vector2(0, this.speed);
        StartCoroutine("TimeToDeath");
    }

    public IEnumerator TimeToDeath()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
