using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beamer : Enemy
{
    public float speed;

    public bool firing;
    public bool readyToFire;
    public Vector2 firePoint;
    private float timeToFire;
    public float maxTimeToFire;
    public float minTimeToFire;
    public LaserBeam laser;

    void Update()
    {
        if (!firing && !readyToFire)
        {
            StartCoroutine("PreliminaryFire");
            readyToFire = true;
        }

        rigidbody.velocity = new Vector2(speed, 0);
    }

    public IEnumerator PreliminaryFire()
    {
        timeToFire = UnityEngine.Random.Range(minTimeToFire, maxTimeToFire);
        yield return new WaitForSeconds(timeToFire);
        laser.StartCoroutine("StartLaser");
    }
}
