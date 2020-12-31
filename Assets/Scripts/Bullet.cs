using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet: MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public virtual bool Friendly => false;

    public int damage { get; set; }
    public float speed;
    public bool friendly => true;

    public virtual void Start()
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}