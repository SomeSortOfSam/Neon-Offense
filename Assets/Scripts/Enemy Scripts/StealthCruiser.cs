using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthCruiser : AltEnemy
{
    public Animator animator;

    public override void Charge()
    {
        base.Charge();
        animator.SetBool("Cloaking", Vector3.Distance(transform.position,Origin) < .5f || Vector3.Distance(transform.position,Player.instance.transform.position) < .5f);
    }
}
