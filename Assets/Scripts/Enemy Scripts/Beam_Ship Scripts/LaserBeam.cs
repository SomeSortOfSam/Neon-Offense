using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{

    public AudioSource source;
    public float volume;

    public Beamer parent;

    void Start()
    {
        parent.firing = true;
        source.volume = volume;
        source.Play();
        StartCoroutine("FizzleOut");
    }

    public IEnumerator FizzleOut()
    {
        yield return new WaitForSeconds(5f);
        parent.firing = false;
        parent.readyToFire = false;
        source.Stop();
        Destroy(this.gameObject);
    }
}
