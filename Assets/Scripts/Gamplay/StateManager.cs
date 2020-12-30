using System;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;
    public GameObject winObject;
    public Vector3 winObjectSpawnPos;
    public static void Lose()
    {
        throw new NotImplementedException();
    }

    public static void Win()
    {
        Instantiate(instance.winObject, instance.winObjectSpawnPos, Quaternion.identity);
    }

    private void Start()
    {
        instance = this;    
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(winObjectSpawnPos, .1f);
    }
}