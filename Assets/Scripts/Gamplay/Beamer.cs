using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beamer : Enemy
{
    public bool firing;

    public GameObject warner;

    public bool preparingToFire;

    public Transform firePoint;

    void Update()
    {
        if (!firing)
        {
            this.rigidbody.velocity = new Vector2(5, 0);
        }
        else
        {
            this.rigidbody.velocity = new Vector2(0, 0);
        }
        if (!preparingToFire)
        {
            StartCoroutine("WarningFire");
            preparingToFire = true;
        }
    }

    public IEnumerator WarningFire()
    {
        GameObject w = Instantiate(warner, firePoint);
        w.TryGetComponent<BeamWarning>(out BeamWarning b);
        b.parent = this;
        b.point = firePoint;
        float timer = UnityEngine.Random.Range(20, 42);
        yield return new WaitForSeconds(timer);
        preparingToFire = false;
    }
}
