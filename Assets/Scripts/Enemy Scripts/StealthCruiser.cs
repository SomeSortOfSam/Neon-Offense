using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthCruiser : Enemy
{
    public Animator animator;

    void Update()
    {
        if (chargeing)
        {
            Charge();

        }
        else
        {
            Idel();
            
        }
    }

    public IEnumerator Uncloak()
    {
        yield return new WaitForSeconds(1f);
        animator.SetBool("Cloaking", false);
    }

    public void Cloak()
    {
        animator.SetBool("Cloaking", true);
    }

}
