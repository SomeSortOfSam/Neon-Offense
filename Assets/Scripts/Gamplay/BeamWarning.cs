using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamWarning : MonoBehaviour
{
    public float timeToFire;

    public float warningFlashAlpha;

    public List<GameObject> beamWarningParts;

    public bool goingUp;

    public GameObject beamSpawner;

    public Beamer parent;

    public Transform point;

    void Start()
    {
        timeToFire = UnityEngine.Random.Range(5, 10);
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject g in beamWarningParts)
        {
            g.TryGetComponent<SpriteRenderer>(out SpriteRenderer s);
            s.color = new Color(s.color.r, s.color.g, s.color.b, warningFlashAlpha);
        }
        if(warningFlashAlpha > .99)
        {
            goingUp = false;
        }else if(warningFlashAlpha < .01)
        {
            goingUp = true;
        }
        if (goingUp)
        {
            warningFlashAlpha += .01f;
        }
        else
        {
            warningFlashAlpha -= .01f;
        }
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(timeToFire);
        GameObject s = Instantiate(beamSpawner, point);
        s.TryGetComponent<BeamSpawner>(out BeamSpawner b);
        b.parent = this.parent;
        b.point = this.point;
        Destroy(this.gameObject);
    }
}
