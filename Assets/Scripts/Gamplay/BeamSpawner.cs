using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamSpawner : MonoBehaviour
{
    public float timeToFire;
    public GameObject beam;

    public Beamer parent;

    public Transform point;

    void Start()
    {
        StartCoroutine("SecondFire");
    }

    public IEnumerator SecondFire()
    {
        yield return new WaitForSeconds(timeToFire);
        GameObject b = Instantiate(beam, point);
        b.TryGetComponent<BeamFire>(out BeamFire f);
        f.parent = this.parent;
        Destroy(this.gameObject);
    }
}
