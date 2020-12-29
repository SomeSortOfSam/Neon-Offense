using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTwo : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("Die");
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
