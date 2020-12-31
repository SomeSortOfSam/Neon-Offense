using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFire : MonoBehaviour
{
    public Beamer parent;

    void Start()
    {
        parent.firing = true;
        StartCoroutine("ToDeath");
    }

    public IEnumerator ToDeath()
    {
        yield return new WaitForSeconds(5f);
        parent.firing = false;
        Destroy(this.gameObject);
    }
}
