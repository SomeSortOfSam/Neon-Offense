using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicPlayerBullet : MonoBehaviour, IBullet
{
    public Rigidbody2D rigidBody;

    public int damage { get; set; } 
    public float speed;
    public bool friendly => true;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(0, speed);
        StartCoroutine("TimeToDeath");
    }

    public IEnumerator TimeToDeath()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
