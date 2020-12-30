using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Rebounder, IGun
{
    Rigidbody2D ridgidBody;
    public float speed = 5;

    public GameObject bullet;
    GameObject IGun.Bullet { get => bullet; set => bullet = value; }
    public int Ammo { get; set; }
    public int firingPause;

    private void Start()
    {
        ridgidBody = GetComponent<Rigidbody2D>();
        Ammo = 1;
        firingPause = 100;
    }
    void Update()
    {
        ridgidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, Input.GetAxisRaw("Vertical") * speed);
        if (Input.GetMouseButton(0) && this.Ammo > 0 && firingPause > 29)
        {
            Instantiate(bullet, gameObject.transform.position + new Vector3(0, 1f, 0), new Quaternion());
            firingPause = 0;
        }
        if (firingPause < 30)
        {
            firingPause++;
        }
    }
}
