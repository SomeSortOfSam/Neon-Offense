using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFirer : MonoBehaviour
{
    public Beamer parent;

    public AudioSource source;
    public AudioClip load;
    public float volume;

    public GameObject beam;

    void Start()
    {
        source.PlayOneShot(load, volume);
        StartCoroutine("SecondFire");
    }

    public IEnumerator SecondFire()
    {
        yield return new WaitForSeconds(3f);
        GameObject b = Instantiate(beam, parent.firePoint);
        b.TryGetComponent<LaserBeam>(out LaserBeam l);
        l.parent = this.parent;
        Destroy(this.gameObject);
    }
}
