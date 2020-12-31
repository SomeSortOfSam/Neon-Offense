using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragoonEnd : Enemy
{
    public List<GameObject> links;

    public int delay;

    void Update()
    {
        foreach (GameObject g in links)
        {
            if (g == null)
            {
                links.Remove(g);
            }
        }
        if (links[0].Equals(this.gameObject))
        {
            //move on own
        }
        else
        {
            //follow the leader
        }
    }
}
