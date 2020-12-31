using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beamer : Enemy
{
    public float speed;

    public bool firing;
    public bool readyToFire;
    public Transform firePoint;
    private float timeToFire;
    public float maxTimeToFire;
    public float minTimeToFire;
    public GameObject warnerObject;

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
        GameObject o = Instantiate(warnerObject, firePoint);
        o.TryGetComponent<Warner>(out Warner w);
        w.parent = this;
    }
}
