using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<GameObject> enemies; 

    void Start()
    {
        foreach(DummyScript en in FindObjectsOfType<DummyScript>()){
            GameObject ne = en.gameObject;
            enemies.Add(ne);
        }
    }

    private void Update()
    {
        if(enemies.Count < 1)
        {
            Debug.Log("end level");
        }
        foreach(GameObject d in enemies)
        {
            int i = 0;
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }
    }

}
