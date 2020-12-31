using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerGun : Gun
{
    public GameObject bullet;

    void Start()
    {
        this.ammo = 1;
        this.firingPause = 100;
    }

    void Update()
    {
        if(Input.GetMouseButton(0) && this.ammo > 0 && firingPause > 59)
        {
            Instantiate(bullet, this.gameObject.transform.position + new Vector3(0, 1f, 0), new Quaternion());
            firingPause = 0;
        }
        if(firingPause < 60)
        {
            firingPause++;
        }
    }
}
