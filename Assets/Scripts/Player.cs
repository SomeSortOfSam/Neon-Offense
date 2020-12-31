using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(AudioSource))]
public class Player : Rebounder
{
    public static Player instance;

    public Rigidbody2D ridgidBody;
    public Animator animator;
    public AudioSource audioSource;

    public AudioClip deathSound;
    public AudioClip hurtSound;
    public AudioClip fireSound;

    public float speed = 5;
    public int health = 3;

    public GameObject bullet;
    public int ammo;
    public int firingPause;

    public static Action<int> damageEvent;

    private void Start()
    {
        instance = this;

        ammo = 1;
        firingPause = 100;

        animator.SetBool("Lost", false);

        damageEvent += OnHurt;
        StateManager.loseEvent += OnLose;
    }

    private void OnLose()
    {
        animator.SetBool("Lost", true);
        audioSource.PlayOneShot(deathSound);
    }

    private void OnHurt(int obj)
    {
        animator.SetTrigger("Hurt");
        audioSource.PlayOneShot(hurtSound);
    }

    void Update()
    {
        ridgidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        if (Input.GetMouseButton(0) && ammo > 0 && firingPause > 69)
        {
            audioSource.PlayOneShot(fireSound);
            Instantiate(bullet, gameObject.transform.position + new Vector3(0, 1f, 0), new Quaternion());
            firingPause = 0;
        }
        if (firingPause < 70)
        {
            firingPause++;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            health--;
            damageEvent?.Invoke(health);
            if(health < 0)
            {
                StateManager.Lose();
            }
        }
    }

    private void OnDestroy()
    {
        damageEvent -= OnHurt;
        StateManager.loseEvent -= OnLose;
    }
}
