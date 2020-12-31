using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragoonHead : Enemy
{

    public List<GameObject> links;

    public int linkAmount;
    public GameObject dLink;
    public GameObject dEnd;

    public int delay;

    public float amplitude;
    public float ampChange;
    public float ampMax; //crest
    public float ampMin; //trough
    public float speed;

    public bool goingUp;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        Origin = transform.position;
        enemies.Add(this);
        links.Add(this.gameObject);

        for(int i=0; i<linkAmount; i++)
        {
            if (i == 0)
            {
                links.Add(Instantiate(dLink, this.transform.position + new Vector3(0, .56f), new Quaternion()));
            }
            else
            {
                links.Add(Instantiate(dLink, links[links.Count - 1].transform.position + new Vector3(0, .883f), new Quaternion()));
            }
        }
        links.Add(Instantiate(dEnd, links[links.Count - 1].transform.position + new Vector3(0, .883f), new Quaternion()));
        foreach(GameObject g in links)
        {
            if(g.TryGetComponent<DragoonLink>(out DragoonLink d))
            {
                foreach(GameObject l in links)
                {
                    d.links.Add(l);
                }
                d.delay = links.IndexOf(g) * delay;
            }
            if(g.TryGetComponent<DragoonEnd>(out DragoonEnd e))
            {
                foreach(GameObject l in links)
                {
                    e.links.Add(l);
                }
                e.delay = links.IndexOf(g) * delay;
            }
        }
    }

    void Update()
    {
        foreach (GameObject g in links)
        {
            if (g == null)
            {
                links.Remove(g);
            }
        }
        //x = A * sinB * y This comment is no longer needed

        rigidbody.velocity = new Vector2(amplitude, -speed);
        if(amplitude > ampMax-ampChange) 
        {
            goingUp = false;
        }
        if(amplitude < ampMin + ampChange)
        {
            goingUp = true;
        }

        if (goingUp)
        {
            amplitude += ampChange;
        }
        else
        {
            amplitude -= ampChange;
        }
    }
}
