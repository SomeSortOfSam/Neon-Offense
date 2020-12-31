using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warner : MonoBehaviour
{
    public GameObject beamFirerObject;

    public Beamer parent;

    private float firingTime;
    public float firingTimeMax;
    public float firingTimeMin;

    public float fadeAlpha;
    public float fadeRate;
    public bool goingUp;
    public List<GameObject> beamParts;

    void Start()
    {
        goingUp = false;
        fadeAlpha = 1;
        StartCoroutine("Fire");
    }

    private void Update()
    {
        foreach (GameObject g in beamParts)
        {
            g.TryGetComponent<SpriteRenderer>(out SpriteRenderer s);
            s.color = new Color(s.color.r, s.color.g, s.color.b, fadeAlpha);
        }
        if (goingUp)
        {
            fadeAlpha += fadeRate;
        }
        else
        {
            fadeAlpha -= fadeRate;
        }
        if(fadeAlpha < .01)
        {
            goingUp = true;
        }
        if(fadeAlpha > .99)
        {
            goingUp = false;
        }
    }

    public IEnumerator Fire()
    {
        firingTime = UnityEngine.Random.Range(firingTimeMin, firingTimeMax);
        yield return new WaitForSeconds(firingTime);
        GameObject f = Instantiate(beamFirerObject, parent.firePoint);
        f.TryGetComponent<BeamFirer>(out BeamFirer b);
        b.parent = this.parent;
        Destroy(this.gameObject);
    }
}
