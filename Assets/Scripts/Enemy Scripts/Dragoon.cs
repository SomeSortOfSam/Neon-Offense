using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragoon : DragoonLink
{
    public int startLinkNum;
    public GameObject link;
    public Sprite end;

    public float amplitude;
    public float ampChange;
    public float ampMax; //crest
    public float ampMin; //trough
    public float speed;

    public bool goingUp;

    public override void Start()
    {
        base.Start();
        DragoonLink[] links = new DragoonLink[startLinkNum];
        for (int i = 0; i < startLinkNum; i++)
        {
            links[i] = Instantiate(link, transform.position + Vector3.up * i, Quaternion.identity).GetComponent<DragoonLink>();
            links[i].parent = i == 0 ? this : links[i - 1];
            if(i == startLinkNum - 1)
            {
                links[i].spriteRenderer = links[i].GetComponent<SpriteRenderer>();
                links[i].spriteRenderer.sprite = end;
            }
        }
    }

    void Update()
    {
        rigidbody.velocity = new Vector2(amplitude, -speed);
        if (amplitude > ampMax - ampChange)
        {
            goingUp = false;
        }
        if (amplitude < ampMin + ampChange)
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
